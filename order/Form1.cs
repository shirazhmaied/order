using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.DataFormats;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Diagnostics;

namespace order
{
    public partial class Form1 : Form
    {
        double tax = 0.05;

        double shipping = 1.50;
        double price;

        double orderTotal;

        public Form1()
        {
            InitializeComponent();

            listBox1.Items.Add("item1");
            listBox1.Items.Add("item2");
            listBox1.Items.Add("item3");
            listBox1.Items.Add("item4");

            textBox1.Text = "Enter order nb";
            textBox2.Text = "Enter shipping address";
            textBox3.Text = "Enter customer name";
        }



        private void Form1_Load(object sender, EventArgs e)
        {


        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private double CalculateItemPrice(string item)
        {
            // Add logic to calculate the price for each item 
            double price;
            string selectedItem = listBox1.SelectedItem.ToString();

            if (selectedItem == "item1")
            {
                price = 8.99;
            }
            else if (selectedItem == "item2")
            {
                price = 10.88;
            }
            else if (selectedItem == "item3")
            {
                price = 12.54;
            }
            else
            {
                price = 6.85;
            }

            return price * int.Parse(textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price;
            // Get the selected item
            string selectedItem = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Please select an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected colors
            List<string> colors = new List<string>();
            if (checkBox1.Checked)
            {
                colors.Add(checkBox1.Text);
            }
            if (checkBox2.Checked)
            {
                colors.Add(checkBox2.Text);

            }
            if (checkBox3.Checked)
            {
                colors.Add(checkBox3.Text);
            }
            if (checkBox4.Checked)
            {
                colors.Add(checkBox4.Text);
            }

            // Get the quantity
            int quantity;
            if (!int.TryParse(textBox4.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            price = CalculateItemPrice(selectedItem);

            string line = $"Item: {selectedItem}, Color: {colors}, Quantity: {quantity}, Price: {price:C}";

             
            textBox5.Text=(line + Environment.NewLine);





          
        }
        


        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox4.Text = " ";
            textBox1.Text = "Enter order nb";
            textBox2.Text = "Enter shipping address";
            textBox3.Text = "Enter customer name";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            // Clear the input fields
            listBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            string selectedItem = listBox1.SelectedItem?.ToString();

            double itemPrice = CalculateItemPrice(selectedItem); 
            double orderTotal = CalculateOrderTotal(itemPrice);
            // Calculate the order total
            _ = CalculateOrderTotal(price);

            // Update the order total label
            string orderNumber = textBox1.Text;
            string shippingAddress = textBox2.Text;

            textBox6.Text = $"Order Total: {orderTotal:C}, Order No: {orderNumber}{Environment.NewLine}Shipping Address: {shippingAddress}";


        }

        private double CalculateOrderTotal(double itemPrice)
        {
           

            

            // Calculate the total price for each item in the receipt
            foreach (string line in textBox6.Lines)
            {
                string[] parts = line.Split(',');
               
         

                if (parts.Length >= 4 && double.TryParse(parts[3].Replace("Price: ", string.Empty).Trim(), out price))
                {
                    orderTotal += price;
                }
            }

            // Add the itemPrice to the orderTotal
            orderTotal += itemPrice;

            return orderTotal;
        }

    }
}




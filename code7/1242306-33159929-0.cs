    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace BMW_CALC_UI
    {
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }
        // Set variables
        double x;
        double y;
        char operation;
        bool EqualsRepeated = false;
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "")
            {
                // Instantiate the instance
                Calculator myCalculator = new Calculator();
                // Store second number
                if (EqualsRepeated == false)
                {
                    if (double.TryParse(txtDisplay.Text, out y))
                        switch (operation)
                        {
                            case '+':
                                // Add addition method
                                txtDisplay.Text = (myCalculator.Add(x, y)).ToString();
                                break;
                            case '-':
                                // Add subtraction method
                                txtDisplay.Text = (myCalculator.Subtract(x, y)).ToString();
                                break;
                            case '*':
                                // Add multiplication method
                                txtDisplay.Text = (myCalculator.Multiply(x, y)).ToString();
                                break;
                            case '/':
                                if (y == 0)
                                {
                                    // Display error message
                                    txtDisplay.Text = "Cannot divide by zero";
                                    return;
                                }
                                // Add division method
                                txtDisplay.Text = (myCalculator.Divide(x, y)).ToString();
                                break;                   
                        }
                    // Set button clicked to true
                    EqualsRepeated = true;               
                }
                else
                {
                    // If equals has already been clicked
                    if (EqualsRepeated == true)
                        if (double.TryParse(txtDisplay.Text, out x))
                        switch (operation)
                        {
                            case '+':
                                // Add addition method
                                txtDisplay.Text = (myCalculator.Add(x, y)).ToString();
                                break;
                            case '-':
                                // Add subtraction method
                                txtDisplay.Text = (myCalculator.Subtract(x, y)).ToString();
                                break;
                            case '*':
                                // Add multiplication method
                                txtDisplay.Text = (myCalculator.Multiply(x, y)).ToString();
                                break;
                            case '/':
                                if (y == 0)
                                {
                                    // Display error message
                                    txtDisplay.Text = "Cannot divide by zero";
                                    return;
                                }
                                // Add division method
                                txtDisplay.Text = (myCalculator.Divide(x, y)).ToString();
                                break;
                        }
                }
                
            }                        
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all data
            txtDisplay.Clear();
            EqualsRepeated = false;
            x = 0;
            y = 0;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
                // Clear last number entered
                if (txtDisplay.Text != "" && txtDisplay.TextLength > 0)
                {
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.TextLength - 1);
                }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Store first number, operation, then clear textbox
            if (double.TryParse(txtDisplay.Text, out x))
            {
                operation = '+';
                txtDisplay.Clear();
            }
        }
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            // Store first number, operation, then clear textbox
            if (double.TryParse(txtDisplay.Text, out x))
            {
                operation = '-';
                txtDisplay.Clear();
            }
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            // Store first number, operation, then clear textbox
            if (double.TryParse(txtDisplay.Text, out x))
            {
                operation = '*';
                txtDisplay.Clear();
            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            // Store first number, operation, then clear textbox
            if (double.TryParse(txtDisplay.Text, out x))
            {
            operation = '/';
            txtDisplay.Clear();
            }
        }
        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Instantiate the instance
            Calculator myCalculator = new Calculator();
            // Perform square root operation
            if (double.TryParse(txtDisplay.Text, out x))
            {
                txtDisplay.Text = (myCalculator.SquareRoot(x)).ToString();
            }
        }
        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            
            // Instantiate the instance
            Calculator myCalculator = new Calculator();
            // Perform reciprocal operation
            if (double.TryParse(txtDisplay.Text, out x))
            {
                txtDisplay.Text = (myCalculator.Reciprocal(x)).ToString();
            }
        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Instantiate the instance
            Calculator myCalculator = new Calculator();
            // Perform sign operation
            if (double.TryParse(txtDisplay.Text, out x))
            {
                txtDisplay.Text = (myCalculator.ChangeSign(x)).ToString();
            }
        }
        private void btnDecimalPoint_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add decimal point if none exist
            if (txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + ".";
            }
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // If textbox starts doesn't start with 0 or Textbox
            // contains a decimal point then it is ok to add a zero
            else if (!txtDisplay.Text.StartsWith("0") || txtDisplay.Text.Contains("."))
            {
                // Add 0 to display
                txtDisplay.Text += "0";
            }
        }
        private void btnOne_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 1 to display
            txtDisplay.Text += "1";
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 4 to display
            txtDisplay.Text += "4";
        }
        private void btnSeven_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 7 to display
            txtDisplay.Text += "7";
        }
        private void btnTwo_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 2 to display
            txtDisplay.Text += "2";
        }
        private void btnFive_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 5 to display
            txtDisplay.Text += "5";
        }
        private void btnEight_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 8 to display
            txtDisplay.Text += "8";
        }
        private void btnThree_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 3 to display
            txtDisplay.Text += "3";
        }
        private void btnSix_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 6 to display
            txtDisplay.Text += "6";
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            // Clear display if error message is present
            if (txtDisplay.Text.Contains("Cannot divide by zero"))
            {
                txtDisplay.Clear();
            }
            // Add 9 to display
            txtDisplay.Text += "9";
        }   
     }
     }

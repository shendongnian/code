            private void button1_Click(object sender, EventArgs e)
            {
               result.Text = Calculate().ToString();
            }
    
    
            private decimal Calculate() {
    
                decimal division = 0;
    
                // This array is to hold the logical operators
            string[] allowed = { "+", "-", "*", "/" };
    
                // If the right operator is selceted then perform the action and return result
                if (operate.Text == "+")
                {
                     division = Convert.ToDecimal(operand1.Text) + Convert.ToDecimal(operand2.Text);
        }
                else if (operate.Text == "-")
                {
                     division = Convert.ToDecimal(operand1.Text) - Convert.ToDecimal(operand2.Text);
    }
                else if (operate.Text == "*")
                {
                     division = Convert.ToDecimal(operand1.Text) * Convert.ToDecimal(operand2.Text);
                }
                else if (operate.Text == "/")
                {
                     division = (Convert.ToDecimal(operand1.Text) / Convert.ToDecimal(operand2.Text));
                }
                // if the operator is not something within the array then display message
                else if (!allowed.Contains(operate.Text))
                {
                    string msg = string.Format("Not a valid operater {0}Please Enter one of the Following:{0}{1}"
                    , Environment.NewLine, string.Join(Environment.NewLine, allowed));
    MessageBox.Show(msg);
                    operate.Text = "";
                }
                return division;
            }
        
        }

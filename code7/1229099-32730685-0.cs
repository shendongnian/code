            private string value;
                 private void textBox1_TextChanged(object sender, EventArgs e)
                    {
                        // at this moment value is still old 
                        var oldValue = value;  
                        if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
                        {
                            MessageBox.Show("Please enter numbers only.");
                            textBox1.Text = oldvalue;
                        }
                        else{
                            value = ((TextBox)sender).Text;
                        }
                    }

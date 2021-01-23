    public string authenticate(string textBox1, string textBox2, string textBox3, bool radio1checked, bool radio2checked)
            {
    
                if (string.IsNullOrEmpty(textBox1))
                {
                    MessageBox.Show("Please Enter All Fields!");
                    return null;
    
                }
                else if (radio1checked)
                {
                    connnectionstring = "data source=" + textBox1 + " ;Initial Catalog =master;Integrated Security = SSPI";
                    return connnectionstring;
    
                }
                else if (radio2checked)
                {
                    connnectionstring = "data source=" + textBox1 + ";Initial Catalog =master;userid =" +textBox2 + ";password = " +textBox3;
                    return connnectionstring;
    
                }
                return null;
            }

            // This is where your code belongs.
            private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
            {
                if ((string)listBox4.SelectedItem == "BE")
                {
    
                    comboBox1.Items.Add("CSE");
                    comboBox1.Items.Add("IT");
                    comboBox1.Items.Add("ME");
                    comboBox1.Items.Add("EX");
                    comboBox1.Items.Add("CE");
                }
                if ((string)listBox4.SelectedItem == "Pharmacy")
                {
                    comboBox1.Items.Add("Pharmaceutical Chemistry");
                    comboBox1.Items.Add("Pharmacology");
                }
                if ((string)listBox4.SelectedItem == "MBA")
                {
                    comboBox1.Items.Add("Retail Management");
                    comboBox1.Items.Add("HR");
                }
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // THIS WAS THE WRONG PLACE
            }   

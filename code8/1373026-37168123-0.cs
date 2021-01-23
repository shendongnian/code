     private void Form1_Load(object sender, EventArgs e)
        {
            listBox4.Items.Add("BE");
            listBox4.Items.Add("MBA");
            listBox4.Items.Add("Pharmacy");
        }
    
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
    comboBox1.Items.Clear();
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
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "2")
            {
                panel1.Visible = true;
            }
            if (comboBox1.SelectedItem == "3")
            {
                panel1.Visible = true;
                panel2.Visible = true;
            }
            if (comboBox1.SelectedItem == "4")
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
 
            }
        }

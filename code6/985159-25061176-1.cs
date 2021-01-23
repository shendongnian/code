    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    { 
        if (comboBox3.SelectedIndex == 1)
        {    
            comboBox1.Items.Clear();       
            comboBox1.Items.Add("Kilometer");
            // and so on
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Meter");
            // and so on
        }
        else if(comboBox3.SelectedIndex == 2)
        {
            comboBox1.Items.Clear();       
            comboBox1.Items.Add("Metric ton");
            // and so on
        }
    }

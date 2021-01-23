    comboBox1.KeyUp +=(comboBox1_KeyUp; // subscribe to an event.
    private void comboBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            comboBox1.Items.Add(comboBox1.Text); // Add
        }
    }
        

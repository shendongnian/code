    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex != -1)
        {
            comboBox2.Enabled = true;
        }
        else
        {
            comboBox2.Enabled = false;
        }
    }

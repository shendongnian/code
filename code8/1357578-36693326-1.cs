    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem == null)
        {
            MessageBox.Show("Meaningful message, user should know what he has done wrong", "Invalid xyz");
            return;
        }
        else if (comboBox2.SelectedItem == null)
        {
            MessageBox.Show("Meaningful message, user should know what he has done wrong", "Invalid xyz");
            return;
        }
        else if (numericUpDown1.Value == 0)
        {
            MessageBox.Show("Meaningful message, user should know what he has done wrong", "Invalid xyz");
            return;
        }
        else if (numericUpDown2.Value == 0)
        {
            MessageBox.Show("Meaningful message, user should know what he has done wrong", "Invalid xyz");
            return;
        }
        else if (numericUpDown3.Value == 0)
        {
            MessageBox.Show("Meaningful message, user should know what he has done wrong", "Invalid xyz");
            return;
        }
        // insert code
    }

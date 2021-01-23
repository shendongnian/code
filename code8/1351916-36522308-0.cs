    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if you select Games option in combobox, fill text box with text from read file "game.txt".
            if (comboBox1.Text == "Games")
            {
                richTextBox2.Text = File.ReadAllText(@"game.txt");
            }
            else if (comboBox1.Text == "Operate")
            {
                richTextBox2.Text = File.ReadAllText(@"operate.txt");
            }
            else if (comboBox1.Text == "Information")
            {
                richTextBox2.Text = File.ReadAllText(@"info.txt");
            }
        }
        catch (Exception ex)
        {
            //display error if files not found. 
            MessageBox.Show(" " + ex.Message);
        }
    }

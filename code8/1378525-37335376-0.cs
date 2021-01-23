    private void textBox1_TextChanged(object sender, EventArgs e)
    {
            Control button = tableLayoutPanel1.Controls["button1"];
            button.Enabled = string.IsNullOrEmpty(textBox1.Text) ? false : true;
    }

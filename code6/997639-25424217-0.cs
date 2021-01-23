    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        label1.Text = textBox1.Text;   // this is for testing
    }
    private void label1_TextChanged(object sender, EventArgs e)
    {
        textBox1.Left  = label1.Right + 6;  // <= this is what you need
        textBox1.Width = panel2.Width - label1.Width - 8;   // <= this is nice to have
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        textBox2.Enabled = !(textBox1.Text.Length >= 1);
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        textBox1.Enabled = !(textBox2.Text.Length >= 1);
    }

    private void KeyButton_Click(object sender, EventArgs e)
    {
        textBox1.Text += ((Button)sender).Text;
    }
    private void ClearButton_Click(object sender, EventArgs e)
    {
        textBox1.Text = string.Empty;
    }

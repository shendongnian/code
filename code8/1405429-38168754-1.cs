    private void KeyButton_Click(object sender, EventArgs e)
    {
        textBox1.Text += ((Button)sender).Text;
    }
    private void ClearButton_Click(object sender, EventArgs e)
    {
        textBox1.Text = string.Empty;
    }
    private void BackspaceButton_Click(object sender, EventArgs e)
    {
        textBox1.Text = textBox1.Text.SubString(0, textBox1.Text.Length-1);
    }

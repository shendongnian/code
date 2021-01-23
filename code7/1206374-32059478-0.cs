    private void textBox2_Leave(object sender, EventArgs e)
    {
        button6.Enabled = !(string.IsNullOrEmpty(textBox2.Text)) && textBox2.Text.Length >= 5;
        if (!button6.Enabled)
        {
            textBox2.Focus();
        }
    }

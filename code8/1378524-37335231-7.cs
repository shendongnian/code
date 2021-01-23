    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var btn = tableLayoutPanel1.Controls.OfType<Button>().Where(x => x.Name == "button1").FirstOrDefault();
        (btn as Button).Enabled = !string.IsNullOrEmpty(textBox1.Text);
    }

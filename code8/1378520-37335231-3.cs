    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var btn = tableLayoutPanel1.Controls.OfType<Button>().Where(x => x.Name == "button1").FirstOrDefault();
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            (btn as Button).Enabled = false;
        }
        else
        {
            (btn as Button).Enabled = true;
        }
    }

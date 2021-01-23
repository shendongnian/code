    private void button1_Click(object sender, EventArgs e)
    {
        string i;
        i = textBox1.Text;
        if (textBox1.Text == "bonjour")
        {
             label1.Text = "Hello";
        }
    
        if (textBox1.Text == "Hello")
        {
            label1.Text = "bonjour";
        }
    }

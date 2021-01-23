    private void button1_Click(object sender, EventArgs e)
    {
        string i;
        i = textBox1.Text;
        if (i == "bonjour")
        {
             label1.Text = "Hello";
        }
    
        if (i == "Hello")
        {
            label1.Text = "bonjour";
        }
    }

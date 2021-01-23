    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if ((textBox1.Text != String.Empty) && (textBox2.Text != String.Empty))
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }
        else
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        if ((textBox1.Text != String.Empty) && (textBox2.Text != String.Empty))
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }
        else
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
    }

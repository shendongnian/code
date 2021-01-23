    private void button2_Click(object sender, EventArgs e)
    {
        loop = !loop;
        if (loop)
        {
            button2.Text = "Repeat: On";
        }
        else
        {
            button2.Text = "Repeat: Off";
        }
    }

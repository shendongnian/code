    private void button1_Click(object sender, EventArgs e)
    {
        // no need to create new instance of Form1.
        for (int i = 0; i < 26; i++) 
        {
           label1.Text += Form1.theCode[i]; // use the static field
        }
    }

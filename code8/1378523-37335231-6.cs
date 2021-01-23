    Button button1;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        // Create 3 buttons
        button1 = new Button();
        button1.Name = "button1";
        tableLayoutPanel1.Controls.Add(button1, 0, 0);
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        button1.Enabled = !string.IsNullOrEmpty(textBox1.Text);
    }

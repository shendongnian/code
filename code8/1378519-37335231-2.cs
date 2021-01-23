    Button button1;
    Button button2;
    Button button3;
    
    private void Form1_Load(object sender, EventArgs e)
    {
    
        // Create 3 buttons
    
        button1 = new Button();
        button1.Name = "button1";
        tableLayoutPanel1.Controls.Add(button1, 0, 0);
    
        button2 = new Button();
        button1.Name = "button2";
        tableLayoutPanel1.Controls.Add(button2, 0, 0);
    
        button3 = new Button();
        button3.Name = "button1";
        tableLayoutPanel1.Controls.Add(button3, 0, 0);
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            button1.Enabled = false;
        }
        else
        {
            button1.Enabled = true;
        }
    }

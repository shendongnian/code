    private void Form1_Load(object sender, EventArgs e)
    {
        // Create 3 buttons
        Button button1 = new Button();
        button1.Name = "button1";
        button1.Tag = 1; //note the Tag property being used
        tableLayoutPanel1.Controls.Add(button1, 0, 0);
        Button button2 = new Button();
        button1.Name = "button2";
        button2.Tag = 2;
        tableLayoutPanel1.Controls.Add(button2, 0, 0);
        Button button3 = new Button();
        button3.Name = "button3";
        button3.Tag = 3;
        tableLayoutPanel1.Controls.Add(button3, 0, 0);
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        foreach (Control c in tableLayoutPanel1.Controls) //iterate through controls
        {
            if ((int)c.Tag == 1) //if Tag is equal then process
            {
                if (c is Button)
                {
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        ((Button)c).Enabled = false;
                    }
                    else
                    {
                        ((Button)c).Enabled = true;
                    }
                    break; //if you have multiple controls to process remove this
                }          //and assign the same tag to the controls you want processed
            }
        }
    }

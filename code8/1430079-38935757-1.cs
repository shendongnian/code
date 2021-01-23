    private void Form1_Load(object sender, EventArgs e)
    {
        bool condition = true;
        if (condition)
        {
    
            Label l_newOne = new Label()
            {
                Text = "Label: ",
                Location = new Point(10, 30)
    
            };
    
            CheckBox chckb_newOne = new CheckBox()
            {
                Text = "Correct",
                Location = new Point(50, 25)
            };
    
            this.Controls.AddRange(new Control[] { chckb_newOne, l_newOne });
    
        }
    
    }

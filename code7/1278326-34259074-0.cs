    private void createButtons()
    {
        flowLayoutPanel1.Controls.Clear();
        for (int i = 0; i < 10; i++)
        {
            RadioButton b = new RadioButton();
            b.Name = i.ToString();
            b.Text = "radiobutton" + i.ToString();
            b.AutoSize = true;
    
            b.CheckedChanged += b_CheckedChanged;
    
            flowLayoutPanel1.Controls.Add(b);
    
        }
    }

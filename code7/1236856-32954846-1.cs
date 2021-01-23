    private void textBox_TC(object sender, EventArgs e)
    {            
        TextBox textBox = (TextBox)sender;
        if(textBox.Text.Length == 1)
        {
            bool sameText = box2.Any(x => x.Text == textBox.Text && 
                                         !x.Equals(textBox));
        
            if(sameText) 
               textBox.BackColor = System.Drawing.Color.Red;
        }
        else if (textBox.Text.Length == 0)
        {
            textBox.BackColor = System.Drawing.Color.White;
        }
    }

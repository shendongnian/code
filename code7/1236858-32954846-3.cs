    private void textBox_TC(object sender, EventArgs e)
    {            
        TextBox textBox = (TextBox)sender;
        if(textBox.Text.Length == 1)
        {
            // Check if Any text box has the same text has the one 
            // firing the event (excluding the firing textbox itself)
            bool sameText = box2.Any(x => x.Text == textBox.Text && 
                                         !x.Equals(textBox));
        
            // Got one textbox with the same text?
            if(sameText) 
               textBox.BackColor = System.Drawing.Color.Red;
        }
        else if (textBox.Text.Length == 0)
        {
            textBox.BackColor = System.Drawing.Color.White;
        }
    }

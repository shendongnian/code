    private void textBox_TC(object sender, EventArgs e)
    {            
        TextBox textBox = (TextBox)sender;
        if(textBox.Text.Length == 1)
        {
            foreach(TextBox t in box2)
                t.BackColor = Color.White;
            // Get all textboxes with the same text 
            var sameText = box2.Where(x => x.Text == textBox.Text);
            if(sameText.Count > 1) 
            {
                foreach(TextBox t in sameText)
                    t.BackColor = Color.Red;
            }
        }
        else if (textBox.Text.Length == 0)
        {
            textBox.BackColor = System.Drawing.Color.White;
        }
    }

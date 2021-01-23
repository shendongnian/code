    ...
    else if (textBox.Text.Length == 0)
    {
        var previusText = textBox.Tag as string;
        if (box1.Count(x => x.Text == previusText && !x.Equals(textBox))==1)
        {
            textBox.BackColor = System.Drawing.Color.White;
        }
    }
    //Keep previous text
    textBox.Tag = textBox.Text;
    ...

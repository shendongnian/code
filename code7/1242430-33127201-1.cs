    ...
    else if (textBox.Text.Length == 0)
    {
        var previusText = textBox.Tag as string;
        var items= box1.Where(x => x.Text == previusText && !x.Equals(textBox)).ToList();
        if (items.Count()==1)
        {
            items[0].BackColor = System.Drawing.Color.White;
        }
    }
    //Keep previous text
    textBox.Tag = textBox.Text;
    ...

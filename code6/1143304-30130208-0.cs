    int count = listBox1.Items.Count -1;
    for (int counter = count; counter >= 0; counter--)
    {
        if (listBox1.GetSelected(counter))
        { 
            string[] words= listBox1.Items[counter].ToString().Replace("\r\n", string.Empty).Split(' ');
            lable_name.Text = words[2];
        }
    }

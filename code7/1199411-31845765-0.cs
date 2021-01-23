    string[] values = textbox1.Text.Split(new string[] { " - " }, StringSplitOptions.None);
    foreach( string value in values)
    {
        if(dictionary.ContainsKey(value))
        {
            textbox2.Text += dictionary[value];
            textbox2.Text += " - "; //Mind that you need to remove this on your last element.
        }
    }

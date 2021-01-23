    var dictionary = new Dictionary<Button, string>();
    dictionary.Add(button1, label1.Text);
    dictionary.Add(button2, label2.Text);
    //  more pairs...
    foreach(var key in dictionary.Keys)
    {
        if(dictionary[key] == "")
        {
            key.Visible = false;
        }
    }

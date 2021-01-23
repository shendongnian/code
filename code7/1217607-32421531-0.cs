    var form = new Form();
    for (int index = 0; index < 5; index++)
    {
        var cb = new CheckButton()
        {
            Left = 10,
            Top = 10 + index * 20,
            Text = "CheckButton" + index,
            GroupIndex = 0 //<= the same group for each CheckButton
        };
        
        form.Controls.Add(cb);
    }
    
    form.Show();

    foreach (var c in this.Controls)
    {
        var _type = c.GetType();
        if (_type == typeof(TextBox))
        {
            // Cast it to a textbox and save it's text property
        }
        elseif (_type == typeof(ListBox)
        {
            // Cast it to a listbox and save it's items property
        }
        // So on...
     }

    listbox.SelectionChanged += (sender, e) =>
    {
        var item = listbox.SelectedItem as ListBoxItem;
        string media = item.Content as string;
        if (media != null)
        {
            //set checkbox to dictionary[media].Checked
            //set updown to dictionary[media].Number
        }
    };

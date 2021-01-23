    PropertyChangedEventHandler handler = (sender, e) =>
    {
        if (e.PropertyName == "IsChecked1" || e.PropertyName == "IsChecked2")
        {
            listbox3.SelectedValue = sender;
        }
    }

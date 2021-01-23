    if (myListBox.SelectionMode == SelectionMode.Multiple)
    {
        var selected = new List<string>();
        foreach (var item in myListBox.Items)
           if (item.Selected)
                selected.Add(item.Text);
        response = string.Join(",", selected);
    }

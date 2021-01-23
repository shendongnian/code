    private void ListCheck_Click(object sender, RoutedEventArgs e)
    {
        ToggleButton btn = (ToggleButton)sender;
        int index = FileListBox.Items.IndexOf(btn.DataContext);
        var item = FileDisplay[index];
        //  This will probably work instead of messing with the index:
        //  var item = btn.DataContext as WhateverTypeFileSelectedContains;
        //  No need to compare a bool to true. 
        if (btn.IsChecked)
        {
            FileSelected.Add(item);
        }
        else if (FileSelected.Contains(item))
        {
            FileSelected.Remove(item);
        }
    }

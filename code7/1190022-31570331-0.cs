    private void ComboBox_DropDownClosed(object sender, System.EventArgs e)
    {
        listView.SelectedItem = null;
        var newSelectedItem = (sender as ComboBox).TryFindParent<ListViewItem>();         
        newSelectedItem.IsSelected = true;
    }

    public void folder_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        savefolder = folder_listbox.SelectedItem.ToString();
        get_files();
    }

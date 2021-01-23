    // Simplified properties
    private IEnumerable<FileData> FileRecordCollection;
    public ObservableCollection<FileData> FileRecord { get; set; }
    // Event handlers for the CheckBoxes
    private void TID_CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        UpdateFileRecord();
    }
    private void TID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        UpdateFileRecord();
    }
    // etc.
    // Method that updates FileRecord
    private void UpdateFileRecord()
    {
        IEnumerable<FileData> groupedCollection = FileRecordCollection;
        if (TID_CheckBox.IsChecked)
            groupedCollection = groupedCollection.GroupBy(item => item.TID).Select(grp => grp.First());
        if (CID_CheckBox.IsChecked)
            groupedCollection = groupedCollection.GroupBy(item => item.CID).Select(grp => grp.First());
        // etc.
        FileRecord = new ObservableCollection<FileData>(groupedCollection);
    }

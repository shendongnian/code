    private void btnOpen_Click(object sender, EventArgs e)
    {
        CheckedListBox.CheckedItemCollection selectedFiles = ckbEntry.CheckedItems;
        foreach (var filename in selectedFiles.Cast<string>()) {
            Process.Start(filename);
        }
    }

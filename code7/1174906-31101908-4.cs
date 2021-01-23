    public string GetDirectory(string whereTo)
    {
        var f = new FolderBrowserDialogWrapper(
            new FolderBrowserDialog { Description = whereTo });
        return GetDirectory(f);
    }
    public string GetDirectory(IFolderBrowserDialogWrapper dialog)
    {
        DialogResult result = dialog.ShowDialog();
        return result == DialogResult.OK ? dialog.SelectedPath : string.Empty;
    }

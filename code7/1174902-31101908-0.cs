    public string GetDirectory(string whereTo)
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog { Description = whereTo };
        DialogResult result = dialog.ShowDialog();
        return GetDirectory(dialog.SelectedPath, result);
    }
    public string GetDirectory(string selectedPath, DialogResult result)
    {
        return result == DialogResult.OK ? selectedPath : string.Empty;
    }

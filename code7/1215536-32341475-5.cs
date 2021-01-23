    private void OpenDirectory(string path)
    {
        try 
        {
            lvExplorer.Items.Clear();
            string newPath = _controller.AddDirectoryAndGetPath(path);
            ShowDirectoriesInListView(newPath);
        }
        catch (Exception ex) 
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void CreateNewFolder_Click(object sender, EventArgs e)
    {
        CustomMenuItem customMenuItem = sender as CustomMenuItem;
        MessageBox.Show(customMenuItem.SelectedTreeNode.FullPath);
    }

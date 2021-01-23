    private void CopyFiles()
    {
        using (var dialog = new CopyFileDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var folder = Path.GetDirectoryName(SelectedItemPaths.First());
                var newFolder = Path.Combine(folder, dialog.FolderName);
                Directory.CreateDirectory(newFolder);
                foreach (var path in SelectedItemPaths)
                {
                    var newPath = Path.Combine(newFolder, Path.GetFileName(path));
                    File.Move(path, newPath);
                }
            }
        }
    }

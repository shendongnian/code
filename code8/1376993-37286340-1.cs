    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
    DialogResult result = folderBrowserDialog.ShowDialog();
    string path = folderBrowserDialog.SelectedPath;
    foreach (var file in Directory.EnumerateFiles(path, "*.chunk*", SearchOption.AllDirectories))
    {
        string filename = Path.GetFileName(file);
        string newPath = path + @"\Test";
        if (!Directory.Exists(newPath))
        {
            Directory.CreateDirectory(newPath);
        }
        using (var reader = new StreamReader(file, true))
        using (var writer = File.CreateText(Path.Combine(newPath, filename + ".txt")))
        {
            string s;
            while ((s = reader.ReadLine()) != null)
            {
                string[] parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    writer.Write(part);
                    writer.Write(',');
                }
                writer.WriteLine();
            }
        }
    }

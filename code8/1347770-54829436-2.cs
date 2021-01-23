    private void LoadStructure(MenuNode rootNode, string path)
    {
        // Gets all files
        string[] files = IO.Directory.GetFiles(path);
        foreach (string file in files)
        {
            // Creates and adds the sub node for all files inside the given folder
            string clearName = IO.Path.GetFileNameWithoutExtension(file);
            MenuNode node = new MenuNode(clearName);
            node.Image = KnownMonikers.TextFile;
            rootNode.Items.Add(node);
        }
        // Gets all sub directories
        string[] directories = IO.Directory.GetDirectories(path);
        foreach (string directory in directories)
        {
            // Creates and adds the sub directory as a sub node
            string clearName = IO.Path.GetFileNameWithoutExtension(directory);
            MenuNode node = new MenuNode(clearName);
            node.Image = KnownMonikers.FolderClosed;
            rootNode.Items.Add(node);
            // Calls the method recursive
            LoadStructure(node, directory);
        }
    }

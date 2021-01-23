    public void DirectorySearch(Node node)
    {
        foreach(string f in Directory.GetFiles(node.Name))
        {
            //initialize a node with the file info
            node.Children.Add(fileNode);
        }
        foreach(var d in Directory.GetDirectories(node.Name)
        {
            //initialize a node with directory info
            node.Children.Add(dirNode);
            DirectorySearch(dirNode);
        }
    }

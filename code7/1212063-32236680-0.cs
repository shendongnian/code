    public string getNodeValue(string path)
    {
            XPathNavigator root;
            string temp;
            root = this.MainDataSource.CreateNavigator();
            temp = root.SelectSingleNode(path, this.NamespaceManager).Value;
            return temp;
    }
    // Set the value
    public void setNodeValue(string path, string value)
    {
            XPathNavigator root, infopathNode;
            root = this.MainDataSource.CreateNavigator();
            infopathNode = null;
            infopathNode = root.SelectSingleNode(path, this.NamespaceManager);
            infopathNode.SetValue(value);
    }

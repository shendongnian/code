    <TreeView Grid.Row="1" x:Name="treeView" Background="White" ItemsSource="{Binding ElementName=me, Path=TreeRoots}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                <TextBlock Text="{Binding Title}"/>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
    
    private XMLDataNode[] treeRoots;
    public XMLDataNode[] TreeRoots
    {
        get { return treeRoots; }
        set
        {
            treeRoots = value;
            NotifyPropertyChanged("TreeRoots");
        }
    }
    
    private void populateTreeview()
        {
            {
                try
                {
                    //Just a good practice -- change the cursor to a 
                    //wait cursor while the nodes populate    
                    this.Cursor = Cursors.Wait;
                    string filePath = System.IO.Path.GetFullPath("TestXML.xml");
                    TreeRoot = RXML.IOManager.GetXMLFromFile(filePath).Last();
                    TreeRoots = new[] { TreeRoot };
                }
                catch (XmlException xExc)

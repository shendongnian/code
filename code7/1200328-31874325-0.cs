    class Product {
        public string Name {get;set;}
        public TreeViewItem Item {get; set;}
        public IEnumerable<TreeViewItem> Items { get { return new[] { item }; }
    }
    
    <TreeView ItemsSource="{Binding Product.Items}">
    
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="{x:Type DataModel:TreeViewItem}" ItemsSource="{Binding SubItems}">
                    <TextBlock Text="{Binding Name}"></TextBlock>
                </HierarchicalDataTemplate>
            </TreeView.Resources>
    
        </TreeView>

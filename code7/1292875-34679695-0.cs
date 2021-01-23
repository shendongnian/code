    TreeViewItem newTVI = new TreeViewItem() { Header = connection.alias.ToString() };
    var tableModelItemStyle = new Style(typeof(TreeViewItem));
    tableModelItemStyle.Setters.Add(new Setter
    {
        Property = TreeViewItem.HeaderProperty,
        //since items will present instances of TableModel, the DataContext will hold
        //the model, so we can define the binding using only the property name
        Value = new Binding("TABLE_NAME"),
    });
    foreach(...)
    {
        ...
        TreeViewItem newTableList = new TreeViewItem
        {
            ...
            ItemContainerStyle = tableModelItemStyle,
        };
        ...
    }

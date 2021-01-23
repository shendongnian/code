    interface INamedObject
    {
        string Name { get; }
    }
    
    var items = datagrid1.ItemsSource as IEnumerable<INamedObject>;
    datagrid1.ItemsSource = items.Where(a => a.Contains("text"));

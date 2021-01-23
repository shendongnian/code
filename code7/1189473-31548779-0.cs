    public MyPropertyCollection()
    {
        Settings = new List<MyProperty>();
    }
    public MyPropertyCollection(IEnumerable<MyProperty> collection)
    {
        Settings = new List<MyProperty>(collection);
    }

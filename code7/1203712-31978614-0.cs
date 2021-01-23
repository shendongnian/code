    public TestObject ParentObject { get; set; }
    
    public TestObjectCollection(TestObject parent)
    {
        ParentObject = parent;
        ...
    }

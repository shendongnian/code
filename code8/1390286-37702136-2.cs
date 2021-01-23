    var test1 = new A()
    {
        IsExpanded = true,
        Name = "Test1",
        Children = new ObservableCollection<A>()
    };
    
    var test2 = new A()
    {
        IsExpanded = true,
        Name = "Test2",
        Children = new ObservableCollection<A>()
    };
    
    var test3 = new A()
    {
        IsExpanded = true,
        Name = "Test3",
        Children = new ObservableCollection<A>()
    };
    
    var test = new A()
    {
        IsExpanded = true,
        Name = "Test",
        Children = new ObservableCollection<A>() {test1, test2, test3}
    };
    
    var clone = new A()
    {
        Children = new ObservableCollection<A>()
    };
    
    clone.UpdateCurrenNode(test);

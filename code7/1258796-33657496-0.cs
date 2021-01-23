    class ItemProxy : T { public T Value { get; set; } }
    
    var list = new List<ItemProxy<MyClass>>();
    list.Insert(new ItemProxy { Value = new MyClass() });
    list.Insert(new ItemProxy { Value = new MyClass() });
    list.Insert(new ItemProxy { Value = new MyClass() });
    
    foreach(var item in list)
    if(item // ...)
    item.Value = new MyClass(); // done, pointer in the list is updated.

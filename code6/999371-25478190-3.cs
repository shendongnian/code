    MyClass item = new MyClass{ id=1 };
    List<MyClass> items = new List<MyClass>();
    items.Add( item );
    
    MyClass getitem = items[0];
    int itemid = getitem.id;

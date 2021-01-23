    var myList = new List<MyClass>() { new MyClass { Id = 1, Name = "Apple" }, 
             new MyClass { Id = 2, Name = "Apple" }, new MyClass { Id = 3, Name = "Orange" } };
    var newList = myList.Select((x, y) => new MyClass
    {
        Id = x.Id,
        Name = x.Name + " " + 
       (myList.GetRange(0, y).Count(z => z.Name == x.Name) == 0 ? string.Empty : 
                                 myList.GetRange(0, y).Count(z => z.Name == x.Name).ToString())
    });

    List<Foo> sourceItems = new List<Foo>(
    new[] {
        new Foo(){ Name="First",   IsSelected=false},
        new Foo(){ Name="Second",  IsSelected=true },
        new Foo(){ Name="Third",   IsSelected=false},
        new Foo(){ Name="Fourth",  IsSelected=true },
        new Foo(){ Name="Fifth",   IsSelected=false},
        new Foo(){ Name="Sixth",   IsSelected=true },
        new Foo(){ Name="Seventh", IsSelected=true },
        new Foo(){ Name="Eighth",  IsSelected=false},
        new Foo(){ Name="Ninth",   IsSelected=false},
        new Foo(){ Name="Tenth",   IsSelected=false}
    });
    
    int startIndex = sourceItems.FindIndex(x => x.IsSelected);
    int endIndex   = sourceItems.FindLastIndex(x => x.IsSelected);
    
    var items = new List<Foo>();
    
    for (int i = startIndex; i <= endIndex; i++)
        items.Add(sourceItems[i]);    

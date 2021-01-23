    List<Foo> sourceItems = new List<Foo>{
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
    };
    int startIndex = sourceItems.FindIndex(item => item.IsSelected);
    int endIndex   = sourceItems.FindLastIndex(item => item.IsSelected);
    var result = sourceItems.Where((item, itemIndex) => itemIndex >= startIndex && itemIndex <= endIndex);

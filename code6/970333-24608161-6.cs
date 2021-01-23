    List<Foo> sourceItems = new List<Foo>
    {
        new Foo(){ Name="First", IsSelected=false},
        ...
        new Foo(){ Name="Tenth", IsSelected=false}
    };
    int endIndex = sourceItems.FindLastIndex(x => x.IsSelected);
    var result = sourceItems
        .SkipWhile(x => !x.IsSelected)
        .TakeWhile((ele, index) => index <= endIndex);

    var tableFoo = context.GetTable<Foo>();
    var tableBar = context.GetTable<Bar>();
    var preselect = tableFoo.Where(o => o.Name == "");
    List<Foo> foos = new List<Foo>();
    foreach (Foo f in preselect) //System.InvalidCastException comes here at the second iteration (Unable to cast to DateTime)
    {
        Foo foo = f;
        foos.Add(foo);
    }
    
    foreach (Foo foo in foos)
    {
        var subselect = tableBar.Where(o => o.Id == foo.Id);
        foreach (Bar bar in subselect)
        {
            foo.bars.Add(bar);
        }
    }

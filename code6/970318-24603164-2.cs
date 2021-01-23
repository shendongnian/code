    static IEnumerable<Foo> BetweenSelected(IEnumerable<Foo> foos)
    {
        var foundFirst = false;
        var acc = new List<Foo>();
    
        foreach (var foo in foos)
        {
            if (foo.IsSelected)
            {
                foundFirst = true;
                foreach (var f in acc)
                    yield return f;
                acc.Clear();
                yield return foo;
            }
            else if (foundFirst)
                acc.Add(foo);
        }
    }

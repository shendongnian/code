    static IEnumerable<Foo> BetweenSelected(List<Foo> foos)
    {
        var lastSelected = foos.Count;
    
        for (var i = 0; i < foos.Count; i++)
        {
            var foo = foos[i];
            if (foo.IsSelected)
            {
                for (var j = lastSelected; j < i; j++)
                    yield return foos[j];
                lastSelected = i+1;
                yield return foo;
            }
        }
    }

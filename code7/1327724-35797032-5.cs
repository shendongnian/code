    public IEnumerable<Foo> Bar()
    {
        using (var r = OpenResource()) 
        {
            while (r.Read ()) 
            {
                yield return new Foo();
            }
        }
    }

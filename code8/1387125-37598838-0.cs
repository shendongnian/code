    private static Expression<Func<Singles, SearchSingles>> CreateSearchSelector()
    {
        return s =>
            new SearchSingles
            {
                Foo = foo,
            };
    }
    
    // Then use it like this
    DataContext.Single.Select(CreateSearchSelector()).ToList();

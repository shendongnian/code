    internal class FooBarDto
    {
        Foo Foo { get; set; }
        Bar Bar { get; set; }
    }
    internal IQueryable<FooBarDto> GetFooBarQuery(DataContext context)
    {
        return
            from foo in foos
            join bar in bars on ...
            select new FooBarDto{ Foo = foo, Bar = bar };
    }

    var foo =
        new []
        {
            new { Id = 1, Name = "a" },
            new { Id = 2, Name = "b" },
            new { Id = 3, Name = "c" }
        };
    
    var bar =
        new []
        {
            new { Id = 1, Name = "d" },
            new { Id = 2, Name = "e" },
            new { Id = 3, Name = "f" }
        };
    
    var baz =
        from a in foo
        join b in bar on a.Id equals b.Id
        select new { a, b };
    
    var qux =
        from a in foo
        join b in bar on a.Id equals b.Id
        select new { a, b };

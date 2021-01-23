    var series = Enumerable.Range(1, 100);
    var categories = new[]
    {
        new Category<int>("Prime", i => MyStaticMethods.IsPrime(i)),
        new Category<int>("Odd", i => i % 2 != 0),
        new Category<int>("Even", i => i % 2 == 0),
    };
    var grouped =
        from i in series
        from c in categories
        where c.Predicate(i)
        group i by c.Name;

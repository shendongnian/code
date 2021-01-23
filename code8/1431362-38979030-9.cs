    IEnumerable<MyClass> All_Items = new List<MyClass>
    {
        new MyClass { Category = "AA", StartDate = new DateTime(2008, 5, 1) },
        new MyClass { Category = "AA", StartDate = new DateTime(2012, 2, 1) },
        new MyClass { Category = "BB", StartDate = new DateTime(2009, 9, 1) },
        new MyClass { Category = "BB", StartDate = new DateTime(2010, 8, 1) },
        new MyClass { Category = "CC", StartDate = new DateTime(2009, 10, 1) }
    }
        // Group by category
        .GroupBy(c => c.Category)
        // For each group, create a new instance of MyClass with the correspondy EndDat value, and then collapse the groups into a single IEnumerable
        .SelectMany(g => g.Select((c, i) =>
            new MyClass
            {
                Category = c.Category,
                StartDate = c.StartDate,
                // If there is at least one date greater than the current one
                // in the next dates to process take it and add -1 days to it
                // If there isn't a greater date, take the default one.
                // Note how i comes from the upper Select, it is the index of the current instance
                EndDate = g.Where((gc, j) => j > i).Any(gc => gc.StartDate > c.StartDate)
                    ? g.Where((gc, j) => gc.StartDate > c.StartDate && j > i).First(gc => gc.StartDate > c.StartDate).StartDate.AddDays(-1)
                    : new DateTime(2099 - 12 - 64)
            }
        ));

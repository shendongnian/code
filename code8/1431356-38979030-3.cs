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
        .SelectMany(g => g.Select(c =>
            new MyClass
            {
                Category = c.Category,
                StartDate = c.StartDate,
                // If there is a grater date in the group (category), take it and add -1 days, if not, take the default 
                EndDate = g.Any(gc => gc.StartDate > c.StartDate)
                    ? ? g.Where(gc => gc.StartDate > c.StartDate).Max(gc => gc.StartDate).AddDays(-1)
                    : new DateTime(2099, 12, 31)
            }
        ));

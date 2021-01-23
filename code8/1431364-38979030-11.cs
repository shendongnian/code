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
        // Colapse the groups into a single IEnumerable
        .SelectMany(g => 
        {
            // Store the already used dates
            List<DateTime> usedDates = new List<DateTime>();
            // Get a new MyClass that has the EndDate set, from each MyClass in the category
            return g.Select(c => 
            {
                // Get all biggerDates that were not used already
                var biggerDates = g.Where(gc => gc.StartDate > c.StartDate && !usedDates.Any(ud => ud == gc.StartDate));
                // Set the endDate to the default one
                DateTime date = new DateTime(2099, 12, 31);
                // If a bigger date was found, mark it as used and set the EndDate to it
                if (biggerDates.Any()) {
                    date = biggerDates.Min(gc => gc.StartDate).AddDays(-1);
                    usedDates.Add(date);
                }
                return new MyClass
                {
                    Category = c.Category,
                    StartDate = c.StartDate,
                    EndDate = date
                };
            });
        });

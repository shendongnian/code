    var records = context
    .Table
    .Select(table => new
    {
        ChildRecordCount = table.Children.Count(child => !child.IsArchived), // This works.
        AltChildRecordCount = table.Children.AsQueryable.Count(HowToExpressThisInCSharp()), // this works too :)
    });

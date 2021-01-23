    static Expression<Func<Menu, bool>> HowToExpressThisInCSharp()
    {
        return x => !x.IsArchived;
    }
    
    var criteria = HowToExpressThisInCSharp();
    var records = context
        .Table
        .AsExpandable()
        .Select(table => new
        {
            ChildRecordCount = table.Children.Count(child => !child.IsArchived),
            AltChildRecordCount = table.Children.Count(criteria.Compile()),
        });

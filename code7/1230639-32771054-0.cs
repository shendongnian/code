    protected override void Seed(EfContext11 context)
    {
        context.Database.ExecuteSqlCommand("your query");
        base.Seed(context);
    }

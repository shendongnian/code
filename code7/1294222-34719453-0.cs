    static void Main(string[] args)
    {
        using (var ctx = new RRPClassesDataContext())
        {
            var foo = GetItems(ctx, i => i.SupiCode.Contains("TestCode"));
            // force execution. context is still open so query works.
            var bar = foo.ToList();
        }
    }
    private static IEnumerable<Item> GetItems(RRPClassesDataContext ctx, Func<Item, bool> filter)
    {
        return ctx.Item.Where(filter);        
    }

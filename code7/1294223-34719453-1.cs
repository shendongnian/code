    private static IEnumerable<Item> GetItems(Func<Item, bool> filter)
    {
        using (var ctx = new RRPClassesDataContext())
        {
            // Forces execution and safely allows the context to be disposed.
            // Still returns an IEnumerable<Item> so the method contract
            // is preserved.
            return ctx.Item.Where(filter).ToList();
        }
    }

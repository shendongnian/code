    private static ICollection<Item> GetItems(Func<Item, bool> filter)
        {
            using (var ctx = new RRPClassesDataContext())
            {
                return ctx.Item.Where(filter).ToList(); <-- this works
            }
        }

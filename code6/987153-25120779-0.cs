    public IEnumerable GetItemsByItemOneID(int itemOneID)
    {
       using (var context = contextFactory.Create())
        {
           return context.ItemTwos.Where(i => i.itemOneID == itemOneID);
        }
    }

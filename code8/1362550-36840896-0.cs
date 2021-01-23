    public List<Item> GetItemsByAccountCode(string code)
    {
        List<Item> itemList = new List<Item>();
        using(DbEntities context = new DbEntities())
        {
            // Get the list of items codes of a specific supplier
            var itemCodes = context.ItemSupplier
                                   .Where(p => p.AccountCode == code)
                                   .Select(p => p.ItemCode)
                                   .ToList();
    
            // Get al the items based on the itemSupList
            // Below is not working
            itemList = context.Item.Where(p => itemCodes.Contains(p.ItemCode));
        }
    }

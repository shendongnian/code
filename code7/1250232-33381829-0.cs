    public IEnumerable<InventoryLocationModel> GetInventoryLocations()
    {
        IEnumerable<InventoryLocationModel> results = null;
        using (DataContext ctx = new DataContext())
        {
            results = (from a in ctx.InventoryLocations select a).ToList();
        }
        return results;
    }

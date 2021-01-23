    public IEnumerable<InventoryLocationModel> GetInventoryLocations()
    {
        using (DataContext ctx = new DataContext())
        {
            return ctx.InventoryLocations.ToList();
        }
    }

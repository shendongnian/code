    public List<InventoryDetailsResponse> GetInventory()
    {
        List<InventoryDetails> result = FromDatabase();
        var list = new List<InventoryDetailsResponse>();
    
        foreach (InventoryDetails match in result)
        {
            var tc = new InventoryDetailsResponse
            {
                InventoryDetailsId = match.InventoryDetailsId,
                ItemName = match.ItemName,
                Price = match.Price,
                Timestamp = match.Timestamp  // Duplicate timestamp in database.
            };
            list.Add(tc);
         }
                
        var res = list.GroupBy(item => item.Timestamp).Select(g => g.First());
        return res;
    }

    public void AddRecentProduct(int id, string name, int maxItems)
    {
        // Check if item already exists
        var item = recentProductList.FirstOrDefault(t => t.ProductId == id);
        // TODO: here if item is found, you could do some more coding to move item to the end of the list, since this is the last product referenced.
        if (item == null)
        {
            // Add item only if it does not exist
            recentProductList.Add(new RecentProduct
            {
                ProductId = id,
                ProdutName = name,
                LastVisited = DateTime.Now,
            });
        }
        
        // Check that recent product list does not exceed maxItems (items at the top of the list are removed on FIFO basis; first in, first out).
        while (recentProductList.Count > maxItems)
        {
            recentProductList.RemoveAt(0);
        }
    }

    public void AddRecentProduct(List<RecentProduct> list, int id, string name, int maxItems)
    {
        // list is current list of RecentProduct objects
        // Check if item already exists
        var item = list.FirstOrDefault(t => t.ProductId == id);
        // TODO: here if item is found, you could do some more coding
        //       to move item to the end of the list, since this is the
        //       last product referenced.
        if (item == null)
        {
            // Add item only if it does not exist
            list.Add(new RecentProduct
            {
                ProductId = id,
                ProdutName = name,
                LastVisited = DateTime.Now,
            });
        }
        
        // Check that recent product list does not exceed maxItems
        // (items at the top of the list are removed on FIFO basis;
        // first in, first out).
        while (list.Count > maxItems)
        {
            list.RemoveAt(0);
        }
    }

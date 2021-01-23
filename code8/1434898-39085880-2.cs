    // Code is activated when accessed via http PUT
    public void PutItem(int itemId, int newSortOrder)
    {
        // using makes sure Context is disposed of properly
        using (var Context = new MyDbContext())
        {
            var oldSortOrder = 0;
    
            IEnumerable<ISortable> itemsToReorder = null;
            // Get moved item from database
            var item = Context.Items.FirstOrDefault(x => x.ItemId == itemId);
    
            // Before we set the new sort order, set a variable to the
            // old one. This will be used to reorder the other items.
            oldSortOrder = item.SortOrder;
    
            // Get all items except the one we grabbed above.
            itemsToReorder = Context.Items.Where(x => x.ItemId != itemId);
    
            // Set the new sort order.
            item.SortOrder = newSortOrder;
    
            // Pass other items into reordering logic.
            ReOrder(itemsToReorder, oldSortOrder, newSortOrder);
    
            // Save all those changes back to the database
            Context.SaveChanges();
        }
    }

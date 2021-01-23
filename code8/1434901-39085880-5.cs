    public static void ReOrder(IEnumerable<ISortable> list, 
        int oldSortOrder, 
        int newSortOrder)
    {
        IEnumerable<ISortable> itemsToReorder;
        // Pare down the items to just those that will be effected by the move.
        // New sort order of 0 means the item has been deleted.
        if (newSortOrder == 0)
        {
            itemsToReorder = list.Where(x => x.SortOrder > oldSortOrder);
        }
        else
        {
            // This is just a long inline if statement. Applies Where()
            // conditions depending on the old and new sort variables.
            itemsToReorder = list.Where(x => (oldSortOrder < newSortOrder
                ? x.SortOrder <= newSortOrder &&
                x.SortOrder > oldSortOrder
                : x.SortOrder >= newSortOrder &&
                x.SortOrder < oldSortOrder));
        }
    
        foreach (var i in itemsToReorder)
        {
            // Original item was moved down
            if (newSortOrder != 0 && oldSortOrder < newSortOrder)
            {
                i.SortOrder -= 1;
            }
            // Original item was moved up
            else if (newSortOrder != 0 && oldSortOrder > newSortOrder)
            {
                i.SortOrder += 1;
            } // Original item was removed.
            else
            {
                i.SortOrder -= 1;
            }
        }
    }

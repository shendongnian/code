    private void AddItem(object item)
    {
        // Make sure to check IsFixedSize because some collections, such as Array,
        // implement IList but throw an exception if you try to call Add on them.
        if (mItemsAsList != null && !mItemsAsList.IsReadOnly && !mItemsAsList.IsFixedSize)
        {
            mItemsAsList.Add(item);
        }
    }

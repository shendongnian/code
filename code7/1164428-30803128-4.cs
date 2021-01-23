    mItemsAsList = newValue as IList;
    if (newValue != null && (mItemsAsList == null || mItemsAsList.IsReadOnly || mItemsAsList.IsFixedSize))
    {
        throw new ArgumentException("The supplied collection must implement IList, not be readonly, and have a variable size.", "newValue");
    }

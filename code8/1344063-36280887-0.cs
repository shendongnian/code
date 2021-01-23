    public static List<T> AssembleItem<T>(DataTable dtItems) where T : new()
    {
        List<T> items = null;
        if (dtItems != null)
        {
            items = new List<T>();
            foreach (DataRow dr in dtItems.Rows)
            {
                T item = new T();
                // populate item from dr
                items.Add(item);
            }
        }
        return items;
    }

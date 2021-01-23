    public static bool IsSorted<T>(IEnumerable<T> items, Comparer<T> comparer = null)
    {
        if (items == null) throw new ArgumentNullException("items");
        if (!items.Skip(1).Any()) return true;  // only one item
        if (comparer == null) comparer = Comparer<T>.Default;
        bool ascendingOrder = true; bool descendingOrder = true;
        T last = items.First();
        foreach (T current in items.Skip(1))
        {
            int diff = comparer.Compare(last, current);
            if (diff > 0)
            {
                ascendingOrder = false;
            }
            if (diff < 0)
            {
                descendingOrder = false;
            }
            last = current;
            if(!ascendingOrder && !descendingOrder) return false;
        }
        return (ascendingOrder || descendingOrder);
    }

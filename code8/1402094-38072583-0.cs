    public ObservableCollection(List<T> list)
        : base((list != null) ? new List<T>(list.Count) : list)
    {
        CopyFrom(list);
    }
    
    private void CopyFrom(IEnumerable<T> collection)
    {
        IList<T> items = Items;
        if (collection != null && items != null)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    items.Add(enumerator.Current);
                }
            }
        }
    }

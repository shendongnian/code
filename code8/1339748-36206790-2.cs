    [Serializable()]
    public class SpecificationCollection : TypedCollectionBase<ProjectSpec>
    {
    }
    [Serializable()]
    public class TypedCollectionBase<TItem> : CollectionBase, IList<TItem>
    {
        #region IList<TItem> Members
        public int IndexOf(TItem item)
        {
            return List.IndexOf(item);
        }
        public void Insert(int index, TItem item)
        {
            List.Insert(index, item);
        }
        public TItem this[int index]
        {
            get { return (TItem)List[index]; }
            set { List[index] = value; }
        }
        #endregion
        #region ICollection<TItem> Members
        public void Add(TItem spec)
        {
            List.Add(spec);
        }
        public bool Contains(TItem item)
        {
            return List.Contains(item);
        }
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public bool IsReadOnly { get { return List.IsReadOnly; } }
        public bool Remove(TItem item)
        {
            int index = IndexOf(item);
            if (index >= 0)
                RemoveAt(index);
            return index >= 0;
        }
        #endregion
        #region IEnumerable<TItem> Members
        public new IEnumerator<TItem> GetEnumerator()
        {
            return List.Cast<TItem>().GetEnumerator();
        }
        #endregion
    }

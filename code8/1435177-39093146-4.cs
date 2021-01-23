    [DataContract]
    public class DrivenList : IList<int>
    {
        [DataMember]
        public List<int> Items = new List<int>();
        [DataMember]
        public string Name { get; set; }
        private DrivenList() { }
        public DrivenList(string name) { this.Name = name; }
        #region Implementation of IList
        public IEnumerator<int> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Items).GetEnumerator();
        }
        public void Add(int item)
        {
            Items.Add(item);
        }
        public void Clear()
        {
            Items.Clear();
        }
        public bool Contains(int item)
        {
            return Items.Contains(item);
        }
        public void CopyTo(int[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }
        public bool Remove(int item)
        {
            return Items.Remove(item);
        }
        public int Count
        {
            get { return Items.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int IndexOf(int item)
        {
            return Items.IndexOf(item);
        }
        public void Insert(int index, int item)
        {
            Items.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            Items.RemoveAt(index);
        }
        public int this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }
        #endregion
    }

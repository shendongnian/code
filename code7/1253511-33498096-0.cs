    public class MyCustomList : IList<ItemWithID>
    {
        private HashSet<int> itemIDs = new HashSet<int>();
        private List<ItemWithID> actualList = new List<ItemWithID>();
    
        public void Add(ItemWithID item)
        {
            actualList.Add(item);
            itemIDs.Add(item.ID);
        }
    
        public bool Remove(ItemWithID item)
        {
            var removed = actualList.Remove(item);
            if (removed)
            {
                itemIDs.Remove(item.ID);
            }
            return removed;
        }
    
        public bool ContainsID(int id)
        {
            return itemIDs.Contains(id);
        }
    
        public int IndexOf(ItemWithID item)
        {
            return actualList.IndexOf(item);
        }
    
        public void Insert(int index, ItemWithID item)
        {
            actualList.Insert(index, item);
            itemIDs.Add(item.ID);
        }
    
        public void RemoveAt(int index)
        {
            itemIDs.Remove(actualList[index].ID);
            actualList.RemoveAt(index);
    
        }
    
        public ItemWithID this[int index]
        {
            get
            {
                return actualList[index];
            }
            set
            {
                actualList[index] = value;
                if (!itemIDs.Contains(value.ID))
                {
                    itemIDs.Add(value.ID);
                }
            }
        }
    
        public void Clear()
        {
            actualList.Clear();
            itemIDs.Clear();
        }
    
        public bool Contains(ItemWithID item)
        {
            return actualList.Contains(item);
        }
    
        public void CopyTo(ItemWithID[] array, int arrayIndex)
        {
            actualList.CopyTo(array, arrayIndex);
        }
    
        public int Count
        {
            get { return actualList.Count; }
        }
    
        public bool IsReadOnly
        {
            get { return false; }
        }
    
        public IEnumerator<ItemWithID> GetEnumerator()
        {
            return actualList.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

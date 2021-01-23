    public class MyList<T>
    {
        private List<T> _TheList;
        public MyList()
        {
            _TheList = new List<T>();
        }
        public List<T> TheList { get { return _TheList; } set { _TheList = value; } }
        public void AddItemFront(T pItem)
        {
            TheList.Insert(0, pItem);
        }
        public void AddItemBehind(T pItem)
        {
            TheList.Add(pItem);
        }
        public void DeleteItemFront(T pItem)
        {
            TheList.RemoveAt(0);
        }
        public void DeleteItemBehind(T pItem)
        {
            TheList.RemoveAt(TheList.Count - 1);
        }
    }

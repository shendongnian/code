    public class MyDefinedList : List<int>
    {
        public void AddItemFront (int pItem)
        {
            Insert(0, pItem);
        }
        public void AddItemBehind (int pItem)
        {
            Add(pItem);
        }
        public void DeleteItemFront()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            RemoveAt(0);
        }
        public void DeleteItemBehind()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            RemoveAt(Count - 1);
        }
    }

           SortedList<string, int> temp = new SortedList<string, int>();
            object item = null;
            bool test = HasItem(temp.Keys, item);
        public bool HasItem(ICollection<string> collection, object item)
        {
            return collection.Contains(item);
        }

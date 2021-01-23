           SortedList<string, int> temp = new SortedList<string, int>();
            bool test = HasItem(temp.Keys, null);
        public bool HasItem(ICollection<string> collection, object item)
        {
            return collection.Contains(item);
        }//This returns false when fed a null

        public void Add(T item)
        {
            list.Add(new ListionaryPair(item));
        }
        public void Add(K key, T item)
        {
            list.Add(new ListionaryPair(key, item));
        }
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

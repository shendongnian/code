        public T this[K key]
        {
            get
            {
                int index = IndexOfKey(key);
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return list[index].Item;
            }
            set
            {
                int index = IndexOfKey(key);
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                list[index] = new ListionaryPair(key, value);
            }
        }

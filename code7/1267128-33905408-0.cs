        public static int IndexOfKey<TKey, TValue>(this OrderedDictionary<TKey, TValue> dictionary, TKey key)
        {
            int index = -1;
            foreach (TKey k in dictionary.Keys)
            {
                index++;
                if (k.Equals(key))
                    return index;
            }
            return -1;
        }

        public void Replace<T1,T2>(Dictionary<T1, T2> d, T1 key, T1 newKey, T2 newValue)
        {
            if (d.ContainsKey(key))
            {
                d.Remove(key);
                d.Add(newKey, newValue);
            }
        }

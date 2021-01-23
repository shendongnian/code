        private int IndexOfKey(K key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var pair = list[i];
                if (pair.HasKey && pair.Key == key)
                {
                    return i;
                }
            }
            return -1;
        }

            if (dictionary.ContainsKey(newKey))
            {
                dictionary.Remove(newKey);
            }
            dictionary.Add(newKey, newValue);
            if (dictionary.ContainsKey(oldKey))
            {
                dictionary.Remove(oldKey);
            }

    public static class DictionaryExtension
    {
        public static bool ContainsAny<K, V>(this Dictionary<K, V> someDict, IEnumerable<K> someList)
        {
            foreach(K listItem in someList)
            {
                if(someDict.ContainsKey(listItem))
                {
                    return true;
                }
            }
            return false;
        }
    }

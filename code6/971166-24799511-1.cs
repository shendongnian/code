    public static class NameValueCollectionExtensions
    {
        public static bool HasKey(this System.Collections.Specialized.NameValueCollection collection, string keyToFind, bool caseSensitive = true)
        {
            foreach (var key in collection.Keys)
            {
                if ((!caseSensitive && key.ToString().ToLower() == keyToFind.ToLower()) || (key.ToString() == keyToFind && caseSensitive))
                {
                    return true;
                }
            }
            return false;
        }
    }

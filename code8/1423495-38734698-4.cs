    public static class ExtensionMethods
    {
        public static string GetTranslationOrDefault(this Dictionary<string, string> dict, string word)
        {
            string result;
            if(!dict.TryGetValue(word, out result)
            {
                //Word was not in the dictionary, return the key.
                result = word;
            }
        }
    }

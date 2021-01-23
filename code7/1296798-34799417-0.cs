        private static void Main(string[] args)
        {
            int x = Method("varName3");
            string word = Method("varName2");
            bool isTrue = Method("varName1");
        }
        private static dynamic Method(string key)
        {
            var dictionary = new Dictionary<string, KeyValuePair<Type, object>>()
            {
                { "varName1", new KeyValuePair<Type, object>(typeof(bool), false) },
                { "varName2", new KeyValuePair<Type, object>(typeof(string), "str") },
                { "varName3", new KeyValuePair<Type, object>(typeof(int), 5) },
            };
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key].Value;
            }
            return null;
        }

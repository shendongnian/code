    public sealed class IndentTracker
    {
        private readonly ThreadLocal<Dictionary<int, string>> _dictionaryLocal =
            new ThreadLocal<Dictionary<int, string>>(() => new Dictionary<int, string>());
        public string GetIndent()
        {
            Dictionary<int, string> dictionary = _dictionaryLocal.Value;
            int count = Environment.StackTrace.Count(a => a == '\n');
            if (!dictionary.Any())
            {
                string initialIndent = string.Empty;
                dictionary.Add(count, initialIndent);
                return initialIndent;
            }
            string indent;
            if (dictionary.TryGetValue(count, out indent))
                return indent;
            string last = dictionary.OrderByDescending(k => k.Key).First(k => k.Key < count).Value;
            string newIndent = last + '\t';
            dictionary.Add(count, newIndent);
            return newIndent;
        }
    }

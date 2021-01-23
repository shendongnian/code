    public class LogScope : IDisposable
    {
        private static readonly ThreadLocal<Stack<Dictionary<string, string>>> currentDictionary =
            new ThreadLocal<Stack<Dictionary<string, string>>>(() => new Stack<Dictionary<string, string>>());
        public LogScope(string key, string value)
        {
            var stack = currentDictionary.Value;
            Dictionary<string, string> newDictionary = null;
            if (stack.Count == 0)
            {
                newDictionary = new Dictionary<string, string>();
            }
            else
            {
                newDictionary = new Dictionary<string, string>(stack.Peek());
            }
            newDictionary[key] = value;
            stack.Push(newDictionary);
        }
        public void Dispose()
        {
            currentDictionary.Value.Pop();
        }
        public static IEnumerable<KeyValuePair<string, string>> Context
        {
            get
            {
                var stack = currentDictionary.Value;
                if (stack.Count == 0)
                {
                    return Enumerable.Empty<KeyValuePair<string, string>>();
                }
                else
                {
                    return stack.Peek();
                }
            }
        }
    }

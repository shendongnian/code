        private static ConcurrentDictionary<string, Queue<string>> dict;
        public static void Main()
        {
            dict = new ConcurrentDictionary<string, Queue<string>>();
        }
        // If I do this on one thread...
        private static void Enqueue(string key, string value)
        {
            dict.AddOrUpdate(
                key,
                k => new Queue<string>(new[] { value }),
                (k, q) =>
                    {
                        q.Enqueue(value);
                        return q;
                    });
        }
        // And I do this on another thread...
        private static string Dequeue(string key)
        {
            string result = null;
            dict.AddOrUpdate(
                "key",
                k => new Queue<string>(),
                (k, q) =>
                    {
                        result = q.Dequeue();
                        return q;
                    });
            return result;
        }

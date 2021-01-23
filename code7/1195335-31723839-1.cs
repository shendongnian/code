    internal static class Program
    {
        private static Dictionary<string, List<string>> _dependencies;
        static void Main(string[] args)
        {
            _dependencies = new Dictionary<string, List<string>>
            {
                {"a", new List<string>{"b","d"}},
                {"b", new List<string>()},
                {"c", new List<string>{"a"}},
                {"d", new List<string>{"b","e","f"}},
                {"e", new List<string>()},
                {"f", new List<string>()}
            };
            Console.WriteLine(string.Join(",", DeepWalkDependencies("a", new HashSet<string>())));
            Console.ReadLine();
        }
        static IEnumerable<string> DeepWalkDependencies(string key, HashSet<string> alreadyVisitedKeys)
        {
            foreach (var d in _dependencies[key])
            {
                if (alreadyVisitedKeys.Add(d))
                {
                    yield return d;
                    foreach (var dd in DeepWalkDependencies(d, alreadyVisitedKeys))
                    {
                        yield return dd;
                    }
                }
            }
        }
    }

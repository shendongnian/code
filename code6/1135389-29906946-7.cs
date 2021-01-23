    class Program
    {
        public static void Main(string[] args)
        {
            var catalog = new ApplicationCatalog();
            var container = new CompositionContainer(catalog);
            IDictionary<int, IApple> dict = new Dictionary<int, IApple>();
            for (int i = 0; i < 10; i++)
            {
                dict.Add(i, container.GetExportedValue<IApple>());
            }
            foreach (var pair in dict)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }

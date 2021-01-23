    class Program
    {
        static void Main()
        {
            var r1 = new Dictionary<double, double> { { 10, 200 } };
            var r2 = new Dictionary<double, double> { { 10, 300 } };
            var r3 = new Dictionary<double, double> { { 10, 500 } };
            var r = Merge(r1, r2, r3);
            foreach (var p in r)
                Console.WriteLine("{0}: {1}", p.Key, p.Value);
        }
        static IDictionary<double, double> Merge(params Dictionary<double, double>[] dicts)
        {
            return dicts.SelectMany(p => p).ToLookup(p => p.Key, p => p.Value).ToDictionary(p => p.Key, p => p.Max());
        }
    }

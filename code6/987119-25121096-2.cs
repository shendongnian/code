    static void Main(string[] args)
    {
        List<List<double>> list = new List<List<double>>();
        list.Add(new List<double> { 1.00, 2.00, 3.00 });
        list.Add(new List<double> { 3.00, 2.00, 8.00 });
        list.Add(new List<double> { 3.00, 9.00, 1.00 });
        list.Add(new List<double> { 3.00, 1.00, 1 });
        var result = list.Select<List<double>, List<KeyValuePair<int, double>>>(sub =>
        {
            List<KeyValuePair<int, double>> elems = new List<KeyValuePair<int, double>>(sub.Count);
            for (int i = 0; i < sub.Count; ++i)
                elems.Add(new KeyValuePair<int, double>(i, sub[i]));
            return elems;
        }).SelectMany((x) => x).GroupBy((x) => x.Key).Select<IGrouping<int, KeyValuePair<int, double>>, double>(x =>
        {
            var y = x.GroupBy(g => g.Value).OrderByDescending(g => g.Count());
            return y.First().First().Value;
        });
        foreach (double val in result)
            Console.Write(val + " ");
        Console.WriteLine();
    }

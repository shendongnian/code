    private struct Element
    {
        public Element(int index, double value)
        {
            Index = index;
            Value = value;
        }
        public int Index;
        public double Value;
    }
    static void Main(string[] args)
    {
        List<List<double>> list = new List<List<double>>();
        list.Add(new List<double> { 1.00, 2.00, 3.00 });
        list.Add(new List<double> { 3.00, 2.00, 8.00 });
        list.Add(new List<double> { 3.00, 9.00, 1.00 });
        list.Add(new List<double> { 3.00, 1.00, 1 });
        var result = list.Select<List<double>, List<Element>>(sub =>
        {
            List<Element> elems = new List<Element>(sub.Count);
            for (int i = 0; i < sub.Count; ++i)
                elems.Add(new Element(i, sub[i]));
            return elems;
        }).SelectMany((x) => x).GroupBy((x) => x.Index).Select<IGrouping<int, Element>, double>(x =>
        {
            var y = x.GroupBy(g => g.Value).OrderByDescending(g => g.Count());
            return y.First().First().Value;
        });
        foreach (double val in result)
            Console.Write(val + " ");
        Console.WriteLine();
    }

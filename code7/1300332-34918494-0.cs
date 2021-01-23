    public class A
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
    }
    public enum GroupByuMode
    {
        GroupBy1,
        GroupBy2,
        GroupBy3,
    }
    ...
 
    var list = new List<A>();
    for (int i = 0; i < 10; ++i)
        for (int j = 0; j < 10; ++j)
            for (int k = 0; k < 10; ++k)
                list.Add(new A { Property1 = i.ToString(), Property2 = j.ToString(), Property3 = k.ToString() });
    var mode = GroupByuMode.GroupBy1;
    Func<A, object> func = a =>
    {
        if (mode == GroupByuMode.GroupBy1)
            return a.Property1;
        else if (mode == GroupByuMode.GroupBy2)
            return String.Format("{0}_{1}", a.Property1, a.Property2);
        else if (mode == GroupByuMode.GroupBy3)
            return String.Format("{0}_{1}_{2}", a.Property1, a.Property2, a.Property3);
        return null;
    };
    var res = list.GroupBy(func).ToList();
    Console.WriteLine(res.Count);
    mode = GroupByuMode.GroupBy2;
    res = list.GroupBy(func).ToList();
    Console.WriteLine(res.Count);

        var input = Enumerable.Range(1, 20);
        int deep = 5;
        var start = DateTime.Now;
        var wiki =  Algorithms.Combinations(input, deep).ToArray();
        Console.WriteLine("wiki perm: {0}", DateTime.Now - start);
        start = DateTime.Now;
        StreamWriter sw0 = new StreamWriter(@"C:\dev\SO\Algo\perm0.txt", false);
        foreach (var item in wiki)
        {
            sw0.WriteLine(String.Join(",", item));
        }
        sw0.Close();
        Console.WriteLine("writing wiki perm: {0}", DateTime.Now - start);
        start = DateTime.Now;
        start = DateTime.Now;
        var result = input
            .Distinct()
            .ToArray()
            .GetCombinations(deep)
            .Select(c => (int[])c.Clone())
            .ToList();
        Console.WriteLine("Ivan perm: {0}", DateTime.Now - start);
        start = DateTime.Now;
        StreamWriter sw1 = new StreamWriter(@"C:\dev\SO\Algo\perm1.txt", false);
        foreach (var item in result)
        {
            sw1.WriteLine(String.Join(",", item));
        }
        sw1.Close();
        Console.WriteLine("writing Ivan perm: {0}", DateTime.Now - start);
        start = DateTime.Now;
        var myPerm = ListPermSO(input.ToArray(), deep);
        Console.WriteLine("my perm: {0}", DateTime.Now - start);
        start = DateTime.Now;
        StreamWriter sw2 = new StreamWriter(@"C:\dev\SO\Algo\perm2.txt", false);
        foreach (var item in myPerm)
        {
            sw2.WriteLine(String.Join(",", item));
        }
        sw2.Close();
        Console.WriteLine("writing my perm: {0}", DateTime.Now - start);
        Console.Read();

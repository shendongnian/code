    static void Main(string[] args)
    {
        List<TestClass> a = new List<TestClass>();
        TestClass t1 = new TestClass();
        t1.Test1 = "a";
        t1.Test2 = "b";
        t1.Test3 = "c";
        t1.Test4 = "d";
        TestClass t2 = new TestClass();
        t2.Test1 = "a2";
        t2.Test2 = "b3";
        t2.Test3 = "c4";
        t2.Test4 = "d5";
        a.Add(t1);
        a.Add(t2);
        var result = (from collRow in a
                     select collRow).Select((d, i) => new 
                     {
                         Data = d,
                         Index = i
                     });
        foreach(var p in result)
        {
            Console.WriteLine(p.Index);
        }
        Console.ReadKey();
    }

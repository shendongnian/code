    static void Main(string[] args)
    {
        List<Func<int>> fs = new List<Func<int>>();
    
        for (int i = 0; i < 5; i++)
        {
            var copyOfi = i;
            fs.Add(() => { return copyOfi; });
        }
    
        for (int i = 0; i < 5; i++)
            Console.WriteLine(fs[i]());
    
        Console.ReadLine();
    }

    static Random R = new Random();
    void Main()
    {
        var a = 10000;
        var b = 10000;
        var n = 200;
        
        int[] counts = new int[10];
        var dc = new DumpContainer().Dump();
    
        while (true)
        {
            var once = Test(a, b, n);
            for (int i = 0; i < once.Length; i++)
                counts[i] += once[i];
            dc.Content = Util.HorizontalRun(true, counts);
        }
    }
    
    public static int[] Test(int a, int b, int n)
    {
        var seen = new HashSet<Tuple<int, int>>();
        var result = new int[10];
    
        for (int index = 0; index < n; index++)
        {
            int tries = 0;
            while (true)
            {
                var av = R.Next(a);
                var bv = R.Next(a);
                var t = Tuple.Create(av, bv);
                if (seen.Contains(t))
                    tries++;
                else
                {
                    seen.Add(t);
                    break;
                }
            }
            result[tries]++;
        }
        return result;
    }

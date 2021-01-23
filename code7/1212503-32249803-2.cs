    public void Add(ref string rate)
    {
        <>c__DisplayClass1 CS$<>8__locals2 = new <>c__DisplayClass1();
        CS$<>8__locals2.r = rate;
        this.Handle.Add("1", new Action<string>(CS$<>8__locals2.<Add>b__0));
        rate = CS$<>8__locals2.r;
    }
    [CompilerGenerated]
    private sealed class <>c__DisplayClass1
    {
        public string r;
        public void <Add>b__0(string m)
        {
            Console.WriteLine(m);
            this.r = m;
        }
    }
 

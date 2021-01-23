    public void Add(ref string rate)
    {
        string r = rate;
        Handle.Add("1", (m) => 
        { 
            Console.WriteLine(m);
            r = m;
        });
        rate = r;
    }

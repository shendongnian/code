    public void Add(ref string rate)
    {
        string r = null;
        Handle.Add("1", (m) => 
        { 
            Console.WriteLine(m);
            r = m;
        });
        rate = r;
    }

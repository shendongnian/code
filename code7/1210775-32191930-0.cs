    private void M(string a)
    {
        Trace.Assert(a != null); // or Debug.Assert(a != null);
        if (a == null)
            Console.WriteLine("a is null");
    }

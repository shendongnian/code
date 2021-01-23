    public void ListDelegates()
    {
        foreach (var m in sum.GetInvocationList())
        {
            Console.WriteLine(m.Method.Name);
        }
    }

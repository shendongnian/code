    public void NewThread(string MethodName, params object[] parameters)
    {
        var mi = this.GetType().GetMethod(MethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Task.Factory.StartNew(() => mi.Invoke(this, parameters), TaskCreationOptions.LongRunning);
    }
    void Add(int i, string s)
    {
        Console.WriteLine(i + " " + s);
    }
---
    NewThread("Add", 1, "test");

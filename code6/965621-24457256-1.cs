    public void NewThread(string MethodName, params object[] parameters)
    {
        var mi = this.GetType().GetMethod(MethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Task.Factory.StartNew(() => mi.Invoke(this, parameters), TaskCreationOptions.LongRunning);
    }
    void Print(int i, string s)
    {
        Console.WriteLine(i + " " + s);
    }
    void Dummy()
    {
        Console.WriteLine("Dummy Method");
    }
---
    NewThread("Print", 1, "test");
    NewThread("Dummy");

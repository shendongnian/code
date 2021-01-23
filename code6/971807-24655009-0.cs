    void Main()
    {
        string s = "Test";
        System.Diagnostics.Debugger.Break(); // This will trigger a dialog to attach a debugger
        Console.ReadLine();
        Console.WriteLine(s);
    }

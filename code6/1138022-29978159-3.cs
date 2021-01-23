    public void CMethod(ref MyDllhelper.Info info)
    {
        Console.WriteLine("C method called");
    }
    public void TimeoutMethod(ref MyDllhelper.Info info)
    {
        Console.WriteLine("Timeout method called");
    }
    var info = new MyDllhelper.Info();
    info.Name = "012345678901234567890"; // Use Name, not name!
    info.flag = 1;
    info.port = 2;
    var helper = new MyDllhelper();
    IntPtr handle = helper.Open(ref info, CMethod, TimeoutMethod); // Use Open, not open!

    static void Main(string[] args)
    {
        var a = new Algo<UserType>();
        var values = a.Execute(new UserInitAndModify(), 10);
        foreach (var v in values)
            Console.WriteLine(v.Time);
    }

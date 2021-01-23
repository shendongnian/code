    void SomeMethod()
    {
        Console.WriteLine("A");
        var thread = new Thread(() =>
        {
            Console.WriteLine("B");
        });
        Console.WriteLine("A");
        thread.Start();
        thread.Join();
        Console.WriteLine("B");
    }

    public static void Main()
    {
        Task.Run(() =>
        {
            throw new Exception();
        });
        Console.ReadLine();
    }

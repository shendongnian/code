    static void Main(string[] args)
    {
        Task t1 = Task.Factory.StartNew(() => {
            Firstmethod();
        });
        Task t2 = Task.Factory.StartNew(() => {
            Secondmethod();
        });
        Task.WaitAll(t1, t2);
        Thirdmethod();
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        var task2 = SayHelloTask();
        task2.Start();//<--Start a "Cold task"
        var result = task2.Result;
        Console.WriteLine(result);
    }

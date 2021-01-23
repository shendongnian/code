    public static event EventHandler<MyEventArgs> MyEvent;
    public static void Main()
    {
        MyEvent += (sender, args) =>
        {
            Console.WriteLine("Event Fired");
            args.DoCallback("hello");
        };
        MyEvent(null, new MyEventArgs<string>(s => Console.WriteLine($"{s} is a string")));
     Console.Read();
    }

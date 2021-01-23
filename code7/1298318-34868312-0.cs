    class Program
    {
        static void Main()
        {
            var observable = Observable
                .Interval(TimeSpan.FromSeconds(3))
                .Zip(Observable.Range(1, 4), (_, count) => count)
                .Repeat();
            observable.Subscribe(Console.WriteLine);
            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }

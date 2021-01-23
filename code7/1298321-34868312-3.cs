    class Program
    {
        static void Main()
        {
            var observable = Observable
                .Interval(TimeSpan.FromSeconds(3))
                //.Zip(Observable.Range(1, 4), (_, count) => count)
                .Select(i=>i+1)
                .Take(4)
                .Repeat();
            using (observable.Subscribe(Console.WriteLine))
            {
                Console.WriteLine("Running...");
                Console.ReadLine();
            }
            Console.WriteLine("Finished!");
        }
    }

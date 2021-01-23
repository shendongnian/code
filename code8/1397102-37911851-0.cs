    class Program
    {
        static void Main(string[] args)
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            var published = Observable.Defer(() =>
            {
                Console.WriteLine("Start"); // Here, you post "Start" to server
                return source;
            })
            .Finally(() => Console.WriteLine("End")) // Here, you post "End"
            .Publish()
            .RefCount();
            Console.ReadLine();
            var disposable = published.Subscribe(x => Console.WriteLine("First " + x));
            Console.ReadLine();
            var disposable2 = published.Subscribe(x => Console.WriteLine("Second " + x));
            Console.ReadLine();
            disposable.Dispose();
            Console.ReadLine();
            disposable2.Dispose();
            Console.ReadLine();
            published.Subscribe(x => Console.WriteLine("Third " + x));
            Console.ReadLine();
        }
    }

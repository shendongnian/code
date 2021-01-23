    class Program
    {
        static int value = 0;
    
        static void Main(string[] args)
        {
            var obs = Observable.Create<int>(observer =>
            {
                Console.WriteLine("Generating");
    
                Interlocked.Increment(ref value);
    
                return Observable.Return(value)
                    .Delay(TimeSpan.FromSeconds(1))
                    .Subscribe(observer);
            })
            .Publish() 
            .RefCount();
            var obs1 = obs.Take(1);
    
            obs1.Subscribe(
                i => Console.WriteLine("First {0}", i), 
                () => Console.WriteLine("First complete"));
            obs1.Subscribe(
                i => Console.WriteLine("Second {0}", i), 
                () => Console.WriteLine("Second complete"));
    
            Console.ReadLine();
    
            obs1.Subscribe(
                i => Console.WriteLine("Third {0}", i), 
                () => Console.WriteLine("Third complete"));
            obs1.Subscribe(
                i => Console.WriteLine("Fourth {0}", i), 
                () => Console.WriteLine("Fourth complete"));
    
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }

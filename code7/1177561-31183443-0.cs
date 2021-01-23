    static void Main(string[] args)
    {
        // event source
        var burstEvents = Observable.Interval(TimeSpan.FromMilliseconds(50));
        var subscription = burstEvents
                
            .Buffer(TimeSpan.FromSeconds(3)) // collect events 3 seconds
            //.Buffer(50) // or collect 50 events
                
            .Subscribe(events =>
            {
                //Console.WriteLine(events.First()); // take only first event
                // or process event collection
                foreach (var e in events)
                    Console.Write(e + " ");
                Console.WriteLine();
            });
        Console.ReadLine();
        return;
    }

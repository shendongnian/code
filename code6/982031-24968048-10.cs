    void Main()
    {
       // This is an asyncrhonous call, it returns straight away
        var subscription = ReadData()
            .Skip(5)                        // Skip first 5 entries, supports LINQ               
            .Delay(TimeSpan.FromSeconds(1)) // Rx operator to delay sequence 1 second
            .Subscribe(x =>
        {
            // Callback when a new Data is read
            // do something with x of type Data
        },
        e =>
        {
            // Optional callback for when an error occurs
        },
        () =>
        {
            //Optional callback for when the sequenc is complete
        }
        );
        // Dispose subscription when finished
        subscription.Dispose();
        Console.ReadKey();
    }

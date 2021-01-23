    void Main()
    {
        // This is an asyncrhonous call, it returns straight away
        var subscription = ReadData().Subscribe(x =>
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

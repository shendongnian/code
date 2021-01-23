    // taking into account Client, manager all are workers
    class Client
    {
        // further whenever you need filter out managers use LINQ OfType<>
        List<Workers> workers;
        public void Add<T>(T worker) where T: Worker
        {
            workers.Add(client);
        }
    }

    public static void Main(string[] args) {
        Task.Run(async () =>
        {
            var tasks = new List<Task> ();
            for (int i = 0; i < 10; i++) {
                tasks.Add (getItemAsync (i));
            }
        
            var finishedTask = await tasks.WhenAny(); // This awaits one task
        }).Wait();
    }

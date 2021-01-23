    static void Main(string[] args)
    {
        // start all async tasks in parallel.
        var tasks = GetEvents().Select(GetEventDetailsAsync);
        // wait for them all to complete. normally you should use await instead of Wait,
        // but you can't because you're in the main method of a console app.
        Task.WhenAll(task).Wait();
    }
    static IEnumerable<Event> GetEvents()
    {
        // build a list of whatever metadata is needed to do your async work.
        // do NOT do any actual async work here.
    }
    async static Task<EventDetailed> GetEventDetailsAsync(Event e)
    {
        // do all async work here, use await as needed,
        // but only for one event (no loops).
    }

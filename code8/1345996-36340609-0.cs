    IObservable<Tuple<Entity, bool>> Replace(IDictionary<Entity, Entity> Map)
    {
        Task<Tuple<Entity, bool>>[] tasks = new Task<Tuple<Entity, bool>>(Map.Count);
        int i = 0;
        foreach (var kvp in Map)
        {
            tasks[i++] = ReplaceAsync(kvp.Key, kvp.Value);
        }
        // Create the IObservable object somehow. Make sure it has the
        // array of tasks in it. E.g. (see below for TaskObservable example)
        TaskObservable<Tuple<Entity, bool>> observable =
            new TaskObservable<Tuple<Entity, bool>>(tasks);
        // Now, start running the observable object. Note: not really all that great
        // to ignore the returned Task object but without more context in your question
        // I can't offer anything more specific. You will probably want to store the
        // Task object *somewhere*, await it, wrap all that in try/catch, etc. to
        // make sure you are correctly monitoring the progress of the task.
        var _ = observable.Run();
        return observable;
    }

    public static async Task<Task> WhenAny( IEnumerable<Task> tasks, Predicate<Task> condition )
    {
        var tasklist = tasks.ToList();
        while ( tasklist.Count > 0 )
        {
            var task = await Task.WhenAny( tasklist );
            if ( condition( task ) )
                return task;
            tasklist.Remove( task );
        }
        return null;
    }

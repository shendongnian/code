    static class Program
    {
        static void Main(string[] args)
        {
            List<Task> runningTasks = new List<Task>();
            IEnumerable<Action> thingsToDo = GetThingsToDo()
            foreach (Action thingToDo in thingsToDo)
            {
                Task startedTask = Task.Run( () => thingToDo);
                runningTasks.Add(startedTask);
            }
            // now that all tasks are started do something else
            // after a while wait until all tasks finished
            Task.WaitAll(runningTasks.ToArray());
        }
    }

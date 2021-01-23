    public static class ListExtensions
    {
        public static void Execute(this IEnumerable<IEvent> eventList)
        {
            foreach (IEvent myEvent in eventList)
            {
                myEvent.Execute();
            }
        }
    }

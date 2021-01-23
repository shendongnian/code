    public static class ListExtensions
    {
        public static void Execute(this IList<IEvent> eventList)
        {
            foreach (IEvent myEvent in eventList)
            {
                myEvent.Execute();
            }
        }
    }

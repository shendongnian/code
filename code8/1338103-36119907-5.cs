    public static class IEnumerableExtensions
    {
        public static void Execute(this IEnumerable<IEvent> eventList)
        {
            foreach (IEvent myEvent in eventList)
            {
                myEvent.Execute();
            }
        }
    }

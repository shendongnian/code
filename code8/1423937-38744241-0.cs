    class Program
    {
        static void Main(string[] args)
        {
            var ec = new EventConsumer();
            var wr = new WeakReference<EventHandler<EventArgs>>(ec.EventReceived);
            EventHandler<EventArgs> target;
            if (wr.TryGetTarget(out target))
            {
                Console.WriteLine("Raising event");
                target(null, EventArgs.Empty);
            }
            // Clear the reference
            target = null;
            Console.WriteLine("Calling System.GC.Collect");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            GC.Collect();
            EventHandler<EventArgs> target2;
            if (wr.TryGetTarget(out target2))
            {
                Console.WriteLine("Raising event");
                target2(null, EventArgs.Empty);
            }
            Console.ReadKey();
        }
    }
    public class EventConsumer
    {
        public void EventReceived(object obj, EventArgs args)
        {
            Console.WriteLine("EventReceived");
        }
    }

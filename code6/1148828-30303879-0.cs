    public class MainClass
    {
        // The "main" BlockingCollection
        // (the one you are already using)
        BlockingCollection<Work> Works = new BlockingCollection<Work>();
        // The "delayed" BlockingCollection
        BlockingCollection<Tuple<DateTime, Work>> Delayed = new BlockingCollection<Tuple<DateTime, Work>>();
        // This is a single worker that will work on the Delayed collection
        // in a separate thread
        public void DelayedWorker()
        {
            Tuple<DateTime, Work> tuple;
            while (Delayed.TryTake(out tuple, -1))
            {
                var dt = DateTime.Now;
                if (tuple.Item1 > dt)
                {
                    Thread.Sleep(tuple.Item1 - dt);
                }
                Works.Add(tuple.Item2);
            }
        }
    }

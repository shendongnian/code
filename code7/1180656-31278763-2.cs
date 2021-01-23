    static class Buffer
    {
        private const int c_MagicThreshold = 10;
        private static ConcurrentQueue<string> s_Messages = new ConcurrentQueue<string>();
        private static object s_LockObj = new object();
        public static void Enqueue(string message)
        {
            s_Messages.Enqueue(message);
            // try to flush every time; spawn on a non-blocking thread and immediately return
            new Task(Flush).Start();
        }
        public static void Flush()
        {
            // do we flush at all?
            if (s_Messages.Count >= c_MagicThreshold)
            {
                lock (s_LockObj)
                {
                    // make sure another thread didn't flush while we were waiting
                    if (s_Messages.Count >= c_MagicThreshold)
                    {
                        List<string> messages = new List<string>();
                        Console.WriteLine("Flushing " + c_MagicThreshold + " messages...");
                        for (int i = 0; i < c_MagicThreshold; i++)
                        {
                            string message;
                            if (!s_Messages.TryDequeue(out message))
                            {
                                throw new InvalidOperationException("How the hell did you manage that?");
                                // or just break from the loop if you don't care much, you spaz
                            }
                            messages.Add(message);
                        }
                        Console.WriteLine("[ " + String.Join(", ", messages) + " ]");
                        // number of new messages enqueued between threshold pass and now
                        Console.WriteLine(s_Messages.Count + " messages remaining in queue");
                    }
                }
            }
        }
    }

    public static class QueueExtensions
    {
        public static int DequeueAndNegate(this Queue<int> queue) 
        {
            return queue.Dequeue() * -1;
        }
        
        // -- or --
        
        public static void NegateAndEnqueue(this Queue<int> queue, int value) 
        {
            queue.Enqueue(value * -1);
        }
    }
    var queue = new Queue<int>(new[] { 1, 2, 3 });
    while (queue.Count > 0) 
    {
        Console.WriteLine(queue.DequeueAndNegate()); // -1 -2 -3
    }

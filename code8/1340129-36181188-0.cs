    public static class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("queue1")] JobClass message,
            TextWriter log)
        {
        }
        public static void ProcessQueueMessages([QueueTrigger("queue2")] JobClass[] messages,
            TextWriter log)
        {
        }
    }

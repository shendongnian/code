    public static void JobQueue1(
        [QueueTrigger("queueName1"),
        StorageAccount("%storageAccount2%")] string filename)
    {
    }
    public static void JobQueue2(
        [QueueTrigger("queueName2"),
        StorageAccount("%storageAccount1%")] string filename)
    {
    }

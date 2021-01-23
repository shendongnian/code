    public static void JobQueue1(
        [QueueTrigger("queueName1"),
        StorageAccount("storageAccount1ConnectionString")] string message)
    {
    }
    public static void JobQueue2(
        [QueueTrigger("queueName2"),
        StorageAccount("storageAccount2ConnectionString")] string message)
    {
    }

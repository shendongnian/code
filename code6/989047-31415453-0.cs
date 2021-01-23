    public static void ProcessQueueMessage([QueueTrigger("testqueue1")] string inputText,
           [Blob("logs/webjob1")]TextWriter writer)
            {
                writer.WriteLine(inputText);
            }

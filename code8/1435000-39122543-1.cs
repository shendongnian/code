    public class Program
    {
        private static void Main()
        {
            var completedEvent = new ManualResetEvent(false);
            ...
            var mainQueue = QueueClient.CreateFromConnectionString("MyConnectionString", "MyQueueName");
            var deadLetterQueue = QueueClient.CreateFromConnectionString("MyConnectionString", QueueClient.FormatDeadLetterPath("MyQueueName"));
            mainQueue.OnMessage((receivedMessage) =>
            {
            }, new OnMessageOptions { AutoComplete = false });
            deadLetterQueue.OnMessage((receivedMessage) =>
            {
            }, new OnMessageOptions { AutoComplete = false });
            completedEvent.WaitOne();
        }
    }

    static string queue = @".\Private$\concurrenttest";
    private static async Task Process(CancellationToken token)
    {
        MessageQueue msMq = new MessageQueue(queue);
        msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(Command1) });
        SemaphoreSlim s = new SemaphoreSlim(15, 15);
        while (true)
        {
            await s.WaitAsync();
            await PeekAsync(msMq);
            Command1 message = await ReceiveAsync(msMq);
            Task.Run(async () =>
            {
                try
                {
                    await HandleMessage(message);
                }
                catch (Exception)
                {
                }
                s.Release();
            });
        }
    }
    private static Task HandleMessage(Command1 message)
    {
        Console.WriteLine("id: " + message.id + ", name: " + message.name);
        Thread.Sleep(1000);
        return Task.FromResult(1);
    }
    private static Task<Message> PeekAsync(MessageQueue msMq)
    {
        return Task.Factory.FromAsync<Message>(msMq.BeginPeek(), msMq.EndPeek);
    }
    public class Command1
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    private static async Task<Command1> ReceiveAsync(MessageQueue msMq)
    {
        var receiveAsync = await Task.Factory.FromAsync<Message>(msMq.BeginReceive(), msMq.EndPeek);
        return (Command1)receiveAsync.Body;
    }

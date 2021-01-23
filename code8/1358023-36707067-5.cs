    #r "Microsoft.ServiceBus"
    using Microsoft.ServiceBus.Messaging;
    public static void Run(BrokeredMessage msg, TraceWriter log)
    {
        log.Info($"C# ServiceBus queue trigger function processed message: {msg}");
    }

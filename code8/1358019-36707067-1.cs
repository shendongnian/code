    using Microsoft.ServiceBus.Messaging;
    public static void Run(BrokeredMessage  message, TraceWriter log)
    {
        log.Verbose("Function has been triggered !!!");
    }

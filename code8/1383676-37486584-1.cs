    #r "Microsoft.ServiceBus"
    using System;
    using Microsoft.ServiceBus.Messaging;
    public static void Run(EventData evt, TraceWriter log)
    {
        var id = evt.Properties["id"];
        log.Info($"C# Event Hub trigger function processed event: {id}");
    }

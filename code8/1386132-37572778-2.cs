    #r "Microsoft.ServiceBus"
    using System;
    using Microsoft.ServiceBus.Messaging;
    public static void Run(MyEvent evt, MyDocument document, TraceWriter log)
    {
        log.Info($"C# Event Hub trigger function processed event: {evt.Id}");
        log.Info($"Document {document.Id} loaded. Value {document.Value}");
    }
    public class MyEvent
    {
        public string Id { get; set; }
        public string DocId { get; set; }
    }
    public class MyDocument
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

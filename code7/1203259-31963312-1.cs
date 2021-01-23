     class SampleApi
     {
        string message_type { get; set; }
        string MessageType { get; private set }
        SampleApi MappMessage()
        {
           MessageType = message_type;
           return this;
        }
     }

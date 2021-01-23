    public List<BaseMessageProcessor> AvailableMessageProcessors;
    ...
    
    AvailableMessageProcessors = new List<BaseMessageProcessor>();
    AvailableMessageProcessors.Add(new RRMessageProcessor(controller));

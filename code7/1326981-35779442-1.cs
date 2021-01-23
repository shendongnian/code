        public class RRMessageProcessor : BaseMessageProcessor, IMessageProcessorOf<RRMessage>
        {
            public RRMessageProcessor(Controller controller) : base(controller) { }
    
            void IMessageProcessor<RRMessage>.Process(RRMessage msg)
            {
                ...
            }
        }

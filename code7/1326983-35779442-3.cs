    public class MultiMessageProcessor : BaseMessageProcessor, IMessageProcessorOf<RRMessage>, IMessageProcessorOf<SSMessage>
    {
        public MultiMessageProcessor(Controller controller) : base(controller) { }
        void IMessageProcessorOf<RRMessage>.Process(RRMessage msg)
        {
            ...
        }
        void IMessageProcessorOf<SSMessage>.Process(SSMessage msg)
        {
            ...
        }
    }

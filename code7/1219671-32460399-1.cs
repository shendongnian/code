    class MyFragment:ITargetBlock<SomeMessage> 
    {
        ....
        
        public Task Completion {get;}
        public void Complete()
        {
            Input.Complete()
        };
        public void Fault(Exception exc)
        {
            Input.Fault(exc);
        }
        DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader,
        	TInput messageValue,ISourceBlock<TInput> source,bool consumeToAccept)
        {
            return Input.OfferMessage(messageHeader,messageValue,source,consumeToAccept);
        }
    }

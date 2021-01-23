    public class ViewModelB : IHandle<ViewModelBMessageEvent>
    {
        private readonly IEventAggregator _Aggregator;
        
        public ViewModelB(IEventAggregator aggregator)
        {
            if (aggregator == null)
                throw new ArgumentNullException("aggregator");
            _Aggregator = aggregator;
            _Aggregator.Subscribe(this);
        }
        public void Handle(ViewModelBMessageEvent message)
        { 
            // do some thing with your message here
            var msg = message.Message;
        }
    }

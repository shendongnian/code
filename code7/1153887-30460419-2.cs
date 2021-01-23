    public class Subscriber : IHandle<SampleEvent>
    {
        public Subscriber(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
        }
        public IEventAggregator EventAggregator { get; private set; }
        public void Handle(SampleEvent message)
        {
            Console.WriteLine(message.LineNumber);
        }
    }

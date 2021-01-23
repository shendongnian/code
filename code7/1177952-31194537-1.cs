    public interface IDoSomthingPublisher
    {
        event EventHandler<CustomEventArgs> DoneSomethingEvent;
    }
    
    public class PublisherClass : IDoSomthingPublisher
    {
        public event EventHandler<CustomEventArgs> DoneSomethingEvent;
    ...
    }
    public class SubscriberClass<T> where T : IDoSomthingPublisher
    {
        private List<T> _publisherClassList;
    
        public List<T> PublisherClassList 
        {
            get
            {
                return _publisherClassList;
            }
            set
            {
                if(_publisherClassList != null)
                {
                    foreach(T item in _publisherClassList)
                    {
                        //unsubscribe old events
                        item -= MyEventHandler;
                    }
                }
    
                _publisherClassList = value;
    
                if(_publisherClassList != null)
                {
                    foreach(T item in _publisherClassList)
                    {
                        //subscribe to new events
                        item += MyEventHandler;
                    }
                }
            }
        }
    }

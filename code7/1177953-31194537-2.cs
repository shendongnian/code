    public class SubscriberClass<T> where T : IDoSomthingPublisher
    {
        private ObserveableCollection<T> _publisherClassList;
    
        public ObserveableCollection<T> PublisherClassList 
        {
            get
            {
                return _publisherClassList;
            }
            set
            {
                if(_publisherClassList != null)
                {
                    _publisherClassList -= CollectionChangedHandler;
                    foreach(T item in _publisherClassList)
                    {
                        //unsubscribe old events
                        item -= MyEventHandler;
                    }
                }
    
                _publisherClassList = value;
    
                if(_publisherClassList != null)
                {
                    _publisherClassList += CollectionChangedHandler;
                    foreach(T item in _publisherClassList)
                    {
                        //subscribe to new events
                        item += MyEventHandler;
                    }
                }
            }
        }
        private void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs args)
        {
            if(args.Action == NotifyCollectionChangedAction.Move)
                return; //Don't need to change subscriptions for moves.
            if(args.Action == NotifyCollectionChangedAction.Reset)
                throw new NotImplementedException("I leave this to you to solve");
            foreach(var item in args.OldItems)
            {
                 item -= MyEventHandler;
            }
            foreach(var item in args.NewItems)
            {
                 item += MyEventHandler;
            }
        }
    }

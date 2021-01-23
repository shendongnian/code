    public class YourViewModel : Screen
    {
        private readonly IEventAggregator _Aggregator;
        private BindableCollection<MyCollection> tags= new BindableCollection<MyCollection>();
    
        public YourViewModel(IEventAggregator aggregator)
        {
            if (aggregator == null)
                throw new ArgumentNullException("aggregator");
            _Aggregator = aggregator;
            _Aggregator.Subscribe(this);
        }
    
        public BindableCollection<MyCollection> AvailableTags
        {
            get
            {
                if (tags== null)
                    tags= new BindableCollection<MyCollection>();
                return tags;
            }
            set
            {
                tags= value;
                NotifyOfPropertyChange(() => MyCollection);
            }
        }  
    }

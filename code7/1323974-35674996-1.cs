    public class DatabaseViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        public DatabaseViewModel(IEventAggregator eventAggregator)
        {
            if (eventAggregator == null)
                throw new ArgumentNullException(nameof(eventAggregator));
            this.eventAggregator = eventAggregator;
            CloseCommand = new DelegateCommand(Close);
        }
        public PcDatabase Database { get; set; }
        public ICommand CloseCommand { get; }
        private void Close()
        {
            // Send a refence to ourself
            eventAggregator
                .GetEvent<CloseDatabaseEvent>()
                .Publish(this);
        }
    }

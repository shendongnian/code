    public partial class App : Application
    {
        private readonly IEventAggregator eventAggregator = new EventAggregator();
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
        }
        public IEventAggregator EventService
        {
            get
            {
                return this.eventAggregator;
            }
        }

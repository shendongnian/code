    public class DatabasesViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        public ObservableCollection<DatabaseViewModel> Databases { get; private set; }
        public CompositeCommand CloseAllCommand { get; }
        public DatabasesViewModel(IEventAggregator eventAggregator)
        {
            if (eventAggregator == null)
                throw new ArgumentNullException(nameof(eventAggregator));
            this.eventAggregator = eventAggregator;
            // Composite Command to close all tabs at once
            CloseAllCommand = new CompositeCommand();
            Databases = new ObservableCollection<DatabaseViewModel>();
            // Add a sample object to the collection
            AddDatabase(new PcDatabase());
            // Register to the CloseDatabaseEvent, which will be fired from the child ViewModels on close
            this.eventAggregator
                .GetEvent<CloseDatabaseEvent>()
                .Subscribe(OnDatabaseClose);
        }
        private void AddDatabase(PcDatabase db)
        {
            // In reallity use the factory pattern to resolve the depencency of the ViewModel and assing the
            // database to it
            var viewModel = new DatabaseViewModel(eventAggregator)
            {
                Database = db
            };
            // Register to the close command of all TabItem ViewModels, so we can close then all with a single command
            CloseAllCommand.RegisterCommand(viewModel.CloseCommand);
            Databases.Add(viewModel);
        }
        // Called when the event is received
        private void OnDatabaseClose(DatabaseViewModel databaseViewModel)
        {
            Databases.Remove(databaseViewModel);
        }
    }

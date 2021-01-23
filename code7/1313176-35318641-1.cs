    public interface IPCDatabaseRepository
    {
    	void GetPCDatabasesAsync(Action<IList<PCDatabase>> resultHandler);
    }
    
    public class PCDatabaseRepository : IPCDatabaseRepository
    {
    	public void GetPCDatabasesAsync(Action<IList<PCDatabase>> resultHandler)
    	{
    		var worker = new BackgroundWorker();
    		
    		worker.DoWork += (sender, args) =>
    		{
    			args.Result = // Execute SQL query...
    		};	
    		
    		worker.RunWorkerCompleted += (sender, args) =>
    		{
    			resultHandler(args.Result as IList<PCDatabase>);
    			worker.Dispose();
    		};
    		
    		worker.RunWorkerAsync();
    	}
    }
    
    public class ViewModelSource : ViewModelBase
    {
    	private readonly IPCDatabaseRepository _databaseRepository;
        private ObservableCollection<PCDatabase> _databases;
    	private bool _isBusy;
    	
        public ViewModelSource(IPCDatabaseRepository databaseRepository /*Dependency injection goes here*/)
        {
    		_databaseRepository = databaseRepository;
    		LoadDatabasesCommand = new RelayCommand(LoadDatabases, () => !IsBusy);
        }
    
    	public ICommand LoadDatabasesCommand { get; private set; }
    	
        public ObservableCollection<PCDatabase> Databases
        {
            get { return _databases; }
            set { _databases = value; OnPropertyChanged("Databases"); }
        }
    
    	public bool IsBusy 
    	{ 
    		get { return _isBusy; }
    		set { _isBusy = value; OnPropertyChanged("IsBusy"); CommandManager.InvalidateRequerySuggested(); }
    	}
    	
        public void LoadDatabases()
        {
    		IsBusy = true;
    		
            _databaseRepository.GetPCDatabasesAsync(results =>
    		{
    			Databases = new ObservableCollection(results);
    			IsBusy = false;
    		});
        }

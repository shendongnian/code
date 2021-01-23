    public class MainViewModel : PropertyChangedBase {
    
        // ... other stuff ... 
    
        public ICommand HomeCommand { get; private set; }
        public ICommand PlayerCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
 
        public MainViewModel(IEventAggregator eventAggregator) {
            // ... other stuff ... //
        
            HomeCommand = new RelayCommand(o => CentralVM = HomeVM, o => true);
            PlayerCommand = new RelayCommand(o => CentralVM = PlayersVM, o => true);
            ImportCommand = new RelayCommand(o => CentralVM = ImportVM, o => true);
        }
    }

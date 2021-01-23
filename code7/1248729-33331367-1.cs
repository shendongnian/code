    public class MainViewModel : BaseObservableObject
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
        public ICommand FirstViewCommand { get; private set; }
        public ICommand SecondViewCommand { get; private set; }
        private bool _canExecuteFirstViewCommand;
        private bool _canExecuteSecondViewCommand;
        public MainViewModel(Vokabel model)
        {
            VokabelViewModelDeutschLatein vokabelViewModelDeutschLatein = new VokabelViewModelDeutschLatein(model);
            VokabelViewModelLateinDeutsch vokabelViewModelLateinDeutsch = new VokabelViewModelLateinDeutsch(model);
            _canExecuteFirstViewCommand = true;
            _canExecuteSecondViewCommand = true;
            CurrentViewModel = vokabelViewModelDeutschLatein;
            FirstViewCommand = new RelayCommand(() => ExecuteFirstViewCommand(vokabelViewModelDeutschLatein));
            SecondViewCommand = new RelayCommand(() => ExecuteSecondViewCommand(vokabelViewModelLateinDeutsch));
        }
        public MainViewModel():this(new Vokabel())
        {
            
        }
        private void ExecuteFirstViewCommand(VokabelViewModelDeutschLatein vokabelViewModelDeutschLatein)
        {
            CurrentViewModel = vokabelViewModelDeutschLatein;
        }
        private void ExecuteSecondViewCommand(VokabelViewModelLateinDeutsch vokabelViewModelLateinDeutsch)
        {
            CurrentViewModel = vokabelViewModelLateinDeutsch;
        }
    }

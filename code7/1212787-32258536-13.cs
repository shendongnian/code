    namespace WpfApplication1.ViewModel
    {
        public class MainViewModel : ViewModelBase // where base implements INotifyPropertyChanged
        {
            private EnumChoice? _selectedEnumChoice;
    
            public MainViewModel()
            {
                EnumChoiceProvider = new ObservableCollection<EnumChoice>
                    (Enum.GetValues(typeof(EnumChoice)).Cast<EnumChoice>());
                ToggleEnumChoiceCommand = new RelayCommand<EnumChoice>
                    (arg => SelectedEnumChoice = arg);
            }
    
            public ObservableCollection<EnumChoice> EnumChoiceProvider { get; set; }
    
            public EnumChoice? SelectedEnumChoice
            {
                get
                {
                    return _selectedEnumChoice;
                }
                set
                {
                    _selectedEnumChoice = value != _selectedEnumChoice ? value : null;
                    RaisePropertyChanged();
                }
            }
    
            public ICommand ToggleEnumChoiceCommand { get; private set; }
        }
    }

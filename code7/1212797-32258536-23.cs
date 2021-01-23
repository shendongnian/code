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
            // Selections    
            public ObservableCollection<EnumChoice> EnumChoiceProvider { get; set; }
            // Current selection    
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
            // "Selection changed" command    
            public ICommand ToggleEnumChoiceCommand { get; private set; }
        }
    }

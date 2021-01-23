    namespace WpfApplication1.ViewModel
    {
        public class MainViewModel : ViewModelBase // where base implements INotifyPropertyChanged
        {
            private HashSet<EnumChoice> _selectedEnumChoices = new HashSet<EnumChoice>();
    
            public MainViewModel()
            {
                EnumChoiceProvider =
                    new ObservableCollection<EnumChoice>
                        (Enum.GetValues(typeof (EnumChoice)).Cast<EnumChoice>());
    
                ToggleEnumChoiceCommand = new RelayCommand<EnumChoice>(arg =>
                    {
                        if (!_selectedEnumChoices.Contains(arg))
                        {
                            _selectedEnumChoices.Add(arg);
                            Console.WriteLine(@"Added {0}", arg);
                        }
                        else
                        {
                            _selectedEnumChoices.Remove(arg);
                            Console.WriteLine(@"Removed {0}", arg);
                        }
                    });
            }
            public ICommand ToggleEnumChoiceCommand { get; private set; }
    
            public ObservableCollection<EnumChoice> EnumChoiceProvider { get; set; }
    
            public HashSet<EnumChoice> SelectedEnumChoices
            {
                get { return _selectedEnumChoices; }
                set { _selectedEnumChoices = value; RaisePropertyChanged(); }
            }
        }
    }

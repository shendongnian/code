    namespace WpfApplication1.ViewModel
    {
        // where base implements INotifyPropertyChanged
        public class MainViewModel : ViewModelBase 
        {
            public MainViewModel()
            {
                EnumChoiceProvider = 
                    new ObservableCollection<EnumChoice>
                        (Enum.GetValues(typeof(EnumChoice)).Cast<EnumChoice>());
            }
    
            public ObservableCollection<EnumChoice> EnumChoiceProvider { get; set; }
        }
    }

    namespace WpfApplication1.ViewModel
    {
        public class MainViewModel : ViewModelBase // where base implements INotifyPropertyChanged
        {
            public MainViewModel()
            {
                EnumChoiceProvider = new ObservableCollection<EnumChoice>(Enum.GetValues(typeof(EnumChoice)).Cast<EnumChoice>());
            }
    
            public ObservableCollection<EnumChoice> EnumChoiceProvider { get; set; }
        }
    }

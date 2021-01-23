    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<ComboBoxItem> ComboBoxOptions;
        public MainPage()
        {
            this.InitializeComponent();
            ComboBoxOptions = new ObservableCollection<ComboBoxItem>();
            ComboBoxOptionsManager.GetComboBoxList(ComboBoxOptions);
            SelectedComboBoxOption = ComboBoxOptions[0];
        }
        ...
        private ComboBoxItem _SelectedComboBoxOption;
        public ComboBoxItem SelectedComboBoxOption
        {
            get
            {
                return _SelectedComboBoxOption;
            }
            set
            {
                if (_SelectedComboBoxOption != value)
                {
                    _SelectedComboBoxOption = value;
                    RaisePropertyChanged("SelectedComboBoxOption");
                }
            }
        }
        ...
    }

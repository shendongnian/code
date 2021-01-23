    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private ViewModel viewModel;
        public ViewModel ViewModel
        {
            get { return viewModel; }
            set 
            {
                viewModel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewModel)));
            }
        }
        public MainPage()
        {
            ViewModel = new ViewModel { };
            this.InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel = new ViewModel {  };//this line has been added
            ViewModel.Text = "x:Bind does not work";
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

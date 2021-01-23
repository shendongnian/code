    public sealed partial class MainPage : Page
    {
        public MainPaigeViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new MainPaigeViewModel();
        }
     
    }

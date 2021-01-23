    public sealed partial class MainPage : Page
    {
        private ViewModel.MainPageViewModel MainPageViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            txt.Text = picker.MinDate + "......" + picker.MaxDate;
            MainPageViewModel = new ViewModel.MainPageViewModel();
        }
    }

    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; } = new MainPageViewModel();
        public MainPage()
        {
            ...
            this.DataContext = ViewModel;
        }
    }

    public sealed partial class MainPage : Page
    {
        public MainPage() { InitializeComponent(); }
        MainPageViewModel ViewModel => DataContext as MainPage;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new MainPageViewModel();
            await DataContext.InitAsync();
        }
    }
    public class MainPageViewModel
    {
        public Task InitAsync()
        {
            // TODO
        }
    }

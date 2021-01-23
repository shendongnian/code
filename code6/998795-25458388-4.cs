    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    
    namespace App1 {
        public sealed partial class MainPage : Page {
            public MainPage() {
                InitializeComponent();
    
                NavigationCacheMode = NavigationCacheMode.Required;
            }
    
            protected override void OnNavigatedTo(NavigationEventArgs e) {
                var myGame = new MyGame();
                myGame.Run(SwapChainPanel1);
            }
        }
    }

    using Windows.UI.Xaml.Controls;
    
    namespace App1 {
        /// <summary>
        ///     An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page {
            public MainPage() {
                InitializeComponent();
                Loaded += (sender, e) => {
                    var myGame = new MyGame();
                    myGame.Run(SwapChainPanel1);
                };
            }
        }
    }

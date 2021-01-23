    using System.Threading.Tasks;
    using System.Windows;
    
    namespace TestAsyncTaskToYoutube
    {
        public partial class MainWindow : Window
        {
            private string token;
    
            public MainWindow()
            {
                InitializeComponent();
                button.Click += button_Click;
            }
    
            private async void button_Click(object sender, RoutedEventArgs e)
            {
                await YoutubeAuth();
                MessageBox.Show(token);
            }
    
            private Task YoutubeAuth()
            {
                token = "test token";
                return Task.FromResult(0);
            }
        }
    }

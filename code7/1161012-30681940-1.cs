    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var dc = new MainViewModel();
            dc.Initialize("Hello", " ", "world");
            this.DataContext = dc;
        }
    }
    public class MainViewModel
    {
        /// <summary>Simple constructor</summary>
        public MainViewModel() { }
        public void Initialize(params object[] arguments)
        {
            //use the task to properly start a new thread as per:
            //http://stackoverflow.com/a/14904107/1144090 and
            //https://msdn.microsoft.com/en-us/library/hh965065.aspx
            //(what would happen if we simply invoke init async here?)
            this.InitializeAsync(arguments)
                .ContinueWith(result =>
                {
                    if (!result.IsFaulted)
                        return;
                    MessageBox.Show("Unexpected error: " + Environment.NewLine + result.Exception.ToString());
                });
        }
        private async Task InitializeAsync(params object[] arguments)
        {
            await Task.Delay(2333);
            MessageBox.Show(String.Concat(arguments));
        }
    }

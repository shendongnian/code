    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel('A', 'Z');
        }
        private void LetterButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Trace.WriteLine("Clicked " + button.Content);
        }
    }
    public class ViewModel
    {
        public ViewModel(char first, char last)
        {
            Letters = Enumerable.Range(first, last - first + 1).Select(l => (char)l);
        }
        public IEnumerable<char> Letters { get; set; }
    }

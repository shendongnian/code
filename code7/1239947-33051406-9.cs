    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LetterButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Trace.WriteLine("Clicked " + button.Content);
        }
    }
    public class LettersViewModel
    {
        public LettersViewModel()
        {
            Letters = Enumerable.Range('A', 'Z' - 'A' + 1).Select(l => (char)l);
        }
        public IEnumerable<char> Letters { get; private set; }
    }

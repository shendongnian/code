    public class Data
    {
        public string Name { get; }
        public Data(string name)
        {
            Name = name;
        }
    }
    public partial class MainWindow
    {
        public Data[] Names { get; } = { new Data("Hello"), new Data("World") };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void OnGridLoaded(object sender, RoutedEventArgs e)
        {
            Grid outerGrid = sender as Grid;
            Grid innerGrid = outerGrid?.FindName("innerGrid") as Grid;
            if (innerGrid != null)
            {
                string name = innerGrid.DataContext as string;
                if (name == "Hello")
                {
                    innerGrid.Visibility = Visibility.Collapsed;
                }
            }
        }
    }

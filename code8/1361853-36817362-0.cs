    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).Players.Add($"Player {(DataContext as ViewModel).Players.Count + 1}");
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as ViewModel).Players.Count > 0)
                (DataContext as ViewModel).Players.RemoveAt(0);
        }
    }
    public class ViewModel
    {
        private ObservableCollection<String> _players = new ObservableCollection<string>();
        public ObservableCollection<String> Players
        {
            get { return _players; }
        }
    }
    public class RowsColumnsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Ceiling(Math.Sqrt((int)value));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

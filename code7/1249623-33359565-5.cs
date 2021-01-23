    public partial class MainWindow : Window
    {
        public List<List<KeyValuePair<string, int>>> ViewModel { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContextChanged += MainWindow_DataContextChanged;
            var viewModel = new List<List<KeyValuePair<string, int>>>();
            for (int f = 0; f < 1; f++)
            {
                var item = new List<KeyValuePair<string, int>>();
                item.Add(new KeyValuePair<string, int>($"{f}, Key1", 1));
                item.Add(new KeyValuePair<string, int>($"{f}, Key2", 2));
                item.Add(new KeyValuePair<string, int>($"{f}, Key3", 3));
                viewModel.Add(item);
            }
            for (int f = 1; f < 2; f++)
            {
                var item = new List<KeyValuePair<string, int>>();
                item.Add(new KeyValuePair<string, int>($"{f}, Key2", 2));
                item.Add(new KeyValuePair<string, int>($"{f}, Key1", 1));
                item.Add(new KeyValuePair<string, int>($"{f}, Key3", 3));
                viewModel.Add(item);
            }
            DataContext = viewModel;
        }
        private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel = DataContext as List<List<KeyValuePair<string, int>>>;
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            for (int f = 0; f < ViewModel.Count; f++)
            {
                var item = new KeyValuePair<string, int>($"{f}, New Key", 1);
                ViewModel[f].Add(item);
            }
        }
        private void ButtonModify_Click(object sender, RoutedEventArgs e)
        {
            for (int f = 0; f < ViewModel.Count; f++)
            {
                for (int j = 0; j < ViewModel[f].Count; j++)
                {
                    ViewModel[f][j] = new KeyValuePair<string, int>($"{f}, Modify key", 1);
                }
            }
        }
    }
    public class DifferenceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get first and second column ItemsSource
            var firstColumnItemsSource = (List<KeyValuePair<string, int>>)values[0];
            var secondColumnItemsSource = (List<KeyValuePair<string, int>>)values[1];
            // Get second  column current KeyValuePair
            var secondKeyValuePair = (KeyValuePair<string, int>)values[2];
            // Get second keyvaluePair index of second column ItemsSource
            int index = secondColumnItemsSource.IndexOf(secondKeyValuePair);
            // Get two column value
            int firstValue = firstColumnItemsSource[index].Value;
            int secondValue = secondKeyValuePair.Value;
            // Get difference value
            var diff = secondValue - firstValue;
            if (diff < 0)
            {
                return "<";
            }
            else if (diff > 0)
            {
                return ">";
            }
            else
            {
                return "none";
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

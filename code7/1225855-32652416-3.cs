    public partial class MainWindow : Window
    {
        private ObservableCollection<MyColor> _colors;
        public IEnumerable<MyColor> Colors
        {
            get { return _colors; }
        }
        private ObservableCollection<Candy> _candies;
        public IEnumerable<Candy> Candies
        {
            get { return _candies; }
        }
        public MainWindow()
        {
            InitializeComponent();
            _colors = new ObservableCollection<MyColor>();
            _candies = new ObservableCollection<Candy>();
            _colors.Add(new MyColor { Name = "(Unspecified)", Id = 0 });
            icColors.ItemsSource = Colors;
            icCandies.ItemsSource = Candies;
        }
        private void btnColor(object sender, RoutedEventArgs e)
        {
            if (txtColor.Text != "")
            {
                uint last_id = Colors.Last<MyColor>().Id;
                _colors.Add(new MyColor() { Name = txtColor.Text, Id = last_id + 1 });
                txtColor.Text = "";
            }
        }
        private void btnNewCandy(object sender, RoutedEventArgs e)
        {
            _candies.Add(new Candy());
        }
        private void btnGetList(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _candies)
            {
                if (item.Name == null || item.Color == null)
                    continue;
                sb.AppendLine(item.Color.Name + " " + item.Name);
            }
            txtColorCandy.Text = sb.ToString();
        }
    }

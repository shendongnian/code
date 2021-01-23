    public partial class MainWindow : Window
    {
        //ObservableCollection<MyColor> Colors;
        //ObservableCollection<Candy> Candies;
        //public IEnumerable<MyColor> Color { get; set; }
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
        private string _candyName;
        public string CandyName
        {
            get { return _candyName; }
            set { _candyName = value; Validate(); }
        }
        private MyColor _selectedColor;
        public MyColor SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                Validate();
            }
        }
        private void Validate()
        {
            if (!(string.IsNullOrWhiteSpace(txtCandyName.Text) && _selectedColor != null))
                btnAddCandy.IsEnabled = true;
        }
        public MainWindow()
        {
            InitializeComponent();
            _colors = new ObservableCollection<MyColor>();
            _candies = new ObservableCollection<Candy>();
            _colors.Add(new MyColor { Name = "(Unspecified)", Id = 0 });
            txtCandyCount.Text = _candies.Count.ToString();
            icColors.ItemsSource = Colors;
            //icCandies.ItemsSource = Candies;
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
            _candies.Add(new Candy
            {
                Name = txtCandyName.Text,
                Color = new MyColor { Id = _selectedColor.Id, Name = _selectedColor.Name }
            });
            txtCandyCount.Text = _candies.Count.ToString();
        }
        private void btnGetList(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _candies)
            {
                sb.AppendLine(item.Color.Name + " " + item.Name);
            }
            txtColorCandy.Text = sb.ToString();
        }
    }

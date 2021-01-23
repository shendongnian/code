        public MainWindow()
        {
            InitializeComponent();
            _comBs =
                this
                    .Root
                    .Children
                    .OfType<ComboBox>()
                    .Where(x => x.Name.StartsWith("comB"))
                    .OrderBy(x => int.Parse(x.Name.Substring("comB".Length)))
                    .ToArray();
        }
        private ComboBox[] _comBs = null;
        private int _comB_index = -1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _comB_index++;
            for (var i = 0; i < _comBs.Length; i++)
            {
                _comBs[i].Visibility = i == _comB_index % _comBs.Length
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register(
            "Shapes", typeof (ObservableCollection<Shape>), typeof (MainWindow),
            new PropertyMetadata(default(ObservableCollection<Shape>)));
        public ObservableCollection<Shape> Shapes
        {
            get { return (ObservableCollection<Shape>) GetValue(ShapesProperty); }
            set { SetValue(ShapesProperty, value); }
        }
        public ObservableCollection<string> Baselist = new ObservableCollection<string> {"a", "b", "c"};
        public ObservableCollection<string> Crystallist = new ObservableCollection<string>{"aa", "bb", "cc"};
    public ObservableCollection<Shape> Shapelist = new ObservableCollection<Shape>();
        private SolidColorBrush _originalColorBrush = Brushes.Tomato;
        private SolidColorBrush _selectedColorBrush;
        public MainWindow()
        {
            this.ResizeMode = System.Windows.ResizeMode.CanMinimize;
            Shapes = new ObservableCollection<Shape>();
            InitializeComponent();
            InitializeLists(Baseforms, CrystalGroups);
        }
        private void InitializeLists(ComboBox Baseforms, ComboBox CrystalGroups)
        {
            Baseforms.ItemsSource = Baselist;
            CrystalGroups.ItemsSource = Crystallist;
            Shape Circle = new Ellipse();
            Circle.Stroke = System.Windows.Media.Brushes.Black;
            Circle.Fill = System.Windows.Media.Brushes.DarkBlue;
            Circle.HorizontalAlignment = HorizontalAlignment.Left;
            Circle.VerticalAlignment = VerticalAlignment.Center;
            Circle.Width = 50;
            Circle.Height = 50;
            Shapelist.Add(Circle);
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(this);
            Shape shape = new Ellipse
            {
                Stroke = Brushes.Black,
                Fill = _originalColorBrush,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 50,
                Height = 50
            };
            shape.Tag = string.Format("{0}:{1}", point.X, point.Y);
            shape.RenderTransform = new TranslateTransform(point.X, point.Y);
            Shapes.Add(shape);
        }
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelected = e.AddedItems.OfType<Shape>().ToList();
            var prevSelected = e.RemovedItems.OfType<Shape>().ToList();
            if (currentSelected.Count > 0)
            {
                currentSelected.ForEach(shape =>
                {
                    _selectedColorBrush = Brushes.CadetBlue;
                    shape.Fill = _selectedColorBrush;
                });
            }
            if (prevSelected.Count > 0)
            {
                prevSelected.ForEach(shape =>
                {
                    shape.Fill = _originalColorBrush;
                });
            }
        }
    }

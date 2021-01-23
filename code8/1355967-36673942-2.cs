    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Shape> _observableCollection;
        private int _coordinator = -1;
        public MainWindow()
        {
            InitializeComponent();
            _observableCollection = new ObservableCollection<Shape>
            {
                new Ellipse{Name = "C", Width = 50, Height = 50, Fill = Brushes.Tomato},
                new Ellipse{Name = "A", Width = 50, Height = 75, Fill = Brushes.Yellow},
                new Rectangle{Name = "D", Width = 50, Height = 75, Fill = Brushes.Blue},
                new Rectangle{Name = "B", Width = 50, Height = 75, Fill = Brushes.CadetBlue},    
            };
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ListBowWithWrapPanel.ItemsSource = _observableCollection;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var list = _observableCollection.ToList();
            _observableCollection.Clear();
            _coordinator *= -1;
            list.Sort((shape, shape1) =>
            {
                var name1 = shape.Name;
                var name2 = shape1.Name;
                return string.Compare(name1, name2, StringComparison.Ordinal) * _coordinator;
            });
            
            list.ForEach(shape =>
            {
                _observableCollection.Add(shape);
            });
        }
    }

    public partial class MainWindow : Window
    {
        List<Point> _board;
        public MainWindow()
        {
            InitializeComponent();
            int rows = 10;
            int columns = 10;
            _board = new List<Point>();
            for(int r = 0; r<rows; r++)
                for (int c = 0; c < columns; c++)
                    _board.Add(new Point(r, c));
            Board.ItemsSource = _board;
        }
        private void CellClick(object sender, MouseButtonEventArgs e)
        {
            var border = (Border)sender;
            var point = (Point) border.Tag;
        }
    }

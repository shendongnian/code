    public partial class MainWindow : Window
    {
        private const int _kwinningCount = 5;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<BoardCell> Board { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Rows = 19;
            Columns = 19;
            Board = new List<BoardCell>(Enumerable.Range(0, Rows * Columns)
                .Select(i => new BoardCell { Color = Brushes.Transparent }));
            DataContext = this;
        }
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BoardCell boardCell = (BoardCell)((FrameworkElement)sender).DataContext;
            boardCell.IncrementColor();
            Color? winningColor = CheckWinner();
            if (winningColor != null)
            {
                MessageBox.Show(winningColor.Value.GetFriendlyName() + " won!");
            }
        }
        private Color _GetColorForBoardCell(int column, int row)
        {
            return Board[column + row * Rows].Color.Color;
        }
        public Color? CheckWinner()
        {
            return CheckWinnerIterator().FirstOrDefault(color => color != null);
        }
        private IEnumerable<Color?> CheckWinnerIterator()
        {
            int columnCount = Columns, rowCount = Rows;
            for (int row = 0; row < rowCount; row++)
            {
                // Horizontal
                yield return CheckWinnerForLine(0, row, columnCount, 1, 0);
                // Diagonals starting in first column, upper-left to lower-right
                yield return CheckWinnerForLine(0, row, rowCount - row, 1, 1);
                // Diagonals starting in first column, lower-left to upper-right
                yield return CheckWinnerForLine(0, row, row + 1, 1, -1);
            }
            for (int column = 0; column < columnCount; column++)
            {
                // Vertical
                yield return CheckWinnerForLine(column, 0, rowCount, 0, 1);
                // Diagonals starting in first row, upper-left to lower-right
                yield return CheckWinnerForLine(column, 0, columnCount - column, 1, 1);
                // Diagonals starting in last row, lower-left to upper-right
                yield return CheckWinnerForLine(column, rowCount - 1, columnCount - column, 1, -1);
            }
        }
        Color? CheckWinnerForLine(int column, int row, int count, int columnIncrement, int rowIncrement)
        {
            // Initialize from the first cell
            int colorCount = 1;
            Color currentColor = _GetColorForBoardCell(column, row);
            while (--count > 0)
            {
                column += columnIncrement;
                row += rowIncrement;
                Color cellColor = _GetColorForBoardCell(column, row);
                if (currentColor != cellColor)
                {
                    // switched colors, so reset for this cell to be the first of the string
                    colorCount = 1;
                    currentColor = cellColor;
                }
                else if (++colorCount == _kwinningCount && cellColor != Colors.Transparent)
                {
                    return cellColor;
                }
            }
            return null;
        }
    }
    public class BoardCell : INotifyPropertyChanged
    {
        private static readonly SolidColorBrush[] _colors =
            { Brushes.Transparent, Brushes.White, Brushes.Black };
        private int _colorIndex;
        public SolidColorBrush Color
        {
            get { return _colors[_colorIndex]; }
            set
            {
                if (value != _colors[_colorIndex])
                {
                    _SetColorIndex(Array.IndexOf(_colors, value));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void IncrementColor()
        {
            _SetColorIndex(_colorIndex < _colors.Length - 1 ? _colorIndex + 1 : 0);
        }
        private void _SetColorIndex(int colorIndex)
        {
            _colorIndex = colorIndex;
            _OnPropertyChanged("Color");
        }
    }
    static class Extensions
    {
        private static readonly Lazy<Dictionary<Color, string>> _colorToName =
            new Lazy<Dictionary<Color, string>>(() => GetColorToNameDictionary());
        private static Dictionary<Color, string> GetColorToNameDictionary()
        {
            Dictionary<Color, string> colorToName = new Dictionary<Color, string>();
            foreach (PropertyInfo pi in
                typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public))
            {
                if (pi.PropertyType == typeof(Color))
                {
                    colorToName[(Color)pi.GetValue(null)] = pi.Name;
                }
            }
            return colorToName;
        }
        public static string GetFriendlyName(this Color color)
        {
            string name;
            if (_colorToName.Value.TryGetValue(color, out name))
            {
                return name;
            }
            return color.ToString();
        }
    }

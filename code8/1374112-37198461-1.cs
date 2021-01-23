    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty SudokuSizeProperty =
            DependencyProperty.Register("SudokuSize", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(null));
    
        private int SudokuSize
        {
            get { return (int)GetValue(SudokuSizeProperty); }
            set { SetValue(SudokuSizeProperty, value); }
        }
    
        public MainWindow()
        {
            SudokuSize = 9;
            InitializeComponent();
        }
    }

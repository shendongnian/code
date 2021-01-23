    public class SudokuUniGrid : UserControl
    {
        public static readonly DependencyProperty myGridSizeProperty =
            DependencyProperty.Register("myGridSize", typeof(int), typeof(UserControl), new FrameworkPropertyMetadata(null));
    
        public int myGridSize
        {
            get { return (int)GetValue(myGridSizeProperty); }
            set { SetValue(myGridSizeProperty, value); }
        }
    
        public SudokuUniGrid()
        {
            InitializeComponent();
    
            Loaded += SudokuUniGrid_Loaded;
        }
    
        private void SudokuUniGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(myGridSize);
    
            // build here
        }
    }

    public partial class MainWindow : Window
    {
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }

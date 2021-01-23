    public partial class MainWindow : Window
    {
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(MainWindow), new PropertyMetadata(false, new PropertyChangedCallback(PropertyChanged)));
        private static void PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            //textbox.ScrollToEnd(); //An object reference is required for the non-static field.
            MainWindow localWindow = (MainWindow)obj;
            Console.WriteLine(localWindow.TestString);
        }
        public string TestString { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            TestString = "test";
            this.DataContext = this;
        }
     }

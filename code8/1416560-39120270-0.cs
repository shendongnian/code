        public partial class MainWindow {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Data", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string), OnDataChanged));
        static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            Debug.WriteLine((string)e.NewValue);
        }
        public string Data {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
        public MainWindow() {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1000);
            dt.Tick += Dt_Tick;
            dt.Start();
        }
        void Dt_Tick(object sender, EventArgs e) {
            Data = new Random().Next(0, 100).ToString();
        }
    }

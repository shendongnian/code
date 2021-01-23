    public partial class MainWindow : Window
    {
        public bool ButtonIsVisible
        {
            get { return (bool)GetValue(ButtonIsVisibleProperty); }
            set { SetValue(ButtonIsVisibleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ButtonIsVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonIsVisibleProperty =
            DependencyProperty.Register("ButtonIsVisible", typeof(bool), typeof(MainWindow), new UIPropertyMetadata(true));
        
        public ObservableCollection<Person> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Person>();
            items.Add(new Person() { Name = "FirstName" });
            items.Add(new Person() { Name = "SecondName" });
            this.DataContext = this;
        }
    }

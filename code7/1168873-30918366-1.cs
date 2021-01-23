    public partial class MainWindow : Window
    {
        public string TextFromParent
        {
            get { return (string)GetValue(TextFromParentProperty); }
            set { SetValue(TextFromParentProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextFromParent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextFromParentProperty =
            DependencyProperty.Register("TextFromParent", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
        
        public ObservableCollection<Model> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Model>();
            items.Add(new Model() { IsChecked = true });
            items.Add(new Model() { IsChecked = false });
            items.Add(new Model() { IsChecked = true });
            items.Add(new Model() { IsChecked = false });
            TextFromParent = "test";
            this.DataContext = this;
        }
    }

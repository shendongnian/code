    public sealed partial class MainWindow
    {
        private static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem",
                typeof(string),
                typeof(MainWindow),
                new PropertyMetadata("Red", SelectedItemChanged, SelectedItemCoerceValue));
        private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        private static object SelectedItemCoerceValue(DependencyObject d, object basevalue)
        {
            if ("Blue".Equals(basevalue))
            {
                return "Green";
            }
            return basevalue;
        }
        public List<string> Values { get; set; } = new List<string>
            {
                "Green", "Red", "Blue",
            };
        public MainWindow()
        {
            InitializeComponent();
            ComboBox.DataContext = this;
        }
    }

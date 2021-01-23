    public partial class Blah : DataGrid
    {
        public Blah()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var templateColumn = this.Resources["DeleteColumn"] as DataGridTemplateColumn;
            this.Columns.Add(templateColumn);
        }
    }

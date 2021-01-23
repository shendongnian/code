     /// <summary>
    /// Interaction logic for CustomGridControl.xaml
    /// </summary>
    public partial class CustomGridControl : UserControl, INotifyPropertyChanged
    {
        public CustomGridControl()
        {
            InitializeComponent();
        }
        private DataTable _DataTableSource;
        public DataTable DataTableSource
        {
            get { return _DataTableSource; }
            set
            {
                _DataTableSource = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DataTableSource"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public DataTable DataTableSourceVersion2
        {
            get { return (DataTable)GetValue(DataTableSourceVersion2Property); }
            set { SetValue(DataTableSourceVersion2Property, value); }
        }
        // Using a DependencyProperty as the backing store for DataTableSourceVersion2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataTableSourceVersion2Property =
            DependencyProperty.Register("DataTableSourceVersion2", typeof(DataTable), typeof(CustomGridControl), new PropertyMetadata(null));
    }

    public partial class Pager
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ObservableCollection<IPagableEntry>), typeof(Pager), new PropertyMetadata(null, OnSourceChanged));
        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(Pager), new PropertyMetadata(1, OnRowsChanged));
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof(Pager), new PropertyMetadata(1, OnColumnsChanged));
        public static readonly DependencyProperty SelectedEntryProperty = DependencyProperty.Register("SelectedEntry", typeof(object), typeof(Pager));
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }
        public object SelectedEntry
        {
            get { return GetValue(SelectedEntryProperty); }
            set { SetValue(SelectedEntryProperty, value); }
        }
        public ObservableCollection<IPagableEntry> Source
        {
            get { return (ObservableCollection<IPagableEntry>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public Pager()
        {
            InitializeComponent();
        }
        private void ListBoxEntriesOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedEntry = (sender as ListBox).SelectedItem;
        }
        private static void OnSourceChanged(DependencyObject pager, DependencyPropertyChangedEventArgs e)
        {
            ((PagerViewModel)(pager as Pager).gridPager.DataContext).Collection =
                (ObservableCollection<IPagableEntry>)e.NewValue;
        }
        private static void OnRowsChanged(DependencyObject pager, DependencyPropertyChangedEventArgs e)
        {
            ((PagerViewModel)(pager as Pager).gridPager.DataContext).Rows =
                (int)e.NewValue;
        }
        private static void OnColumnsChanged(DependencyObject pager, DependencyPropertyChangedEventArgs e)
        {
            ((PagerViewModel)(pager as Pager).gridPager.DataContext).Columns =
                (int)e.NewValue;
        }
    }

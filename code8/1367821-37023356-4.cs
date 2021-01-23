        /// <summary>
    /// Interaction logic for GridLineControl.xaml
    /// </summary>
    public partial class GridLineControl : UserControl
    {
        public GridLineControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty NumberOfColumnsProperty = DependencyProperty.Register(
            "NumberOfColumns", typeof (int), typeof (GridLineControl), new PropertyMetadata(default(int), NumberOfColumnsChangedCallback));
        private static void NumberOfColumnsChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var numberOfRows = (int)dependencyObject.GetValue(NumberOfRowsProperty);
            var numberOfColumns = (int)args.NewValue;
            if (numberOfColumns == 0 || numberOfRows == 0) return;
            var rowModelsCollection = GetRowModelsCollection(numberOfRows, numberOfColumns);
            dependencyObject.SetValue(RowModelsProperty, rowModelsCollection);
        }
        public int NumberOfColumns
        {
            get { return (int) GetValue(NumberOfColumnsProperty); }
            set { SetValue(NumberOfColumnsProperty, value); }
        }
        public static readonly DependencyProperty NumberOfRowsProperty = DependencyProperty.Register(
            "NumberOfRows", typeof (int), typeof (GridLineControl), new PropertyMetadata(default(int), NumberOfRowsChangedCallback));
        private static void NumberOfRowsChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var numberOfRows = (int)args.NewValue;
            var numberOfColumns = (int)dependencyObject.GetValue(NumberOfColumnsProperty);
            if(numberOfColumns == 0 || numberOfRows == 0) return;
            var rowModelsCollection = GetRowModelsCollection(numberOfRows, numberOfColumns);
            dependencyObject.SetValue(RowModelsProperty, rowModelsCollection);
        }
        private static ObservableCollection<RowModel> GetRowModelsCollection(int numberOfRows, int numberOfColumns)
        {
            var rowModelsCollection = new ObservableCollection<RowModel>();
            for (var i = 0; i < numberOfRows; i++)
            {
                rowModelsCollection.Add(new RowModel(numberOfColumns) {Position = (i + 1).ToString()});
            }
            return rowModelsCollection;
        }
        public int NumberOfRows
        {
            get { return (int) GetValue(NumberOfRowsProperty); }
            set { SetValue(NumberOfRowsProperty, value); }
        }
        public static readonly DependencyProperty RowModelsProperty = DependencyProperty.Register("RowModels",
            typeof(ObservableCollection<RowModel>), typeof(GridLineControl),
            new PropertyMetadata(default(ObservableCollection<RowModel>)));
        public ObservableCollection<RowModel> RowModels
        {
            get { return (ObservableCollection<RowModel>)GetValue(RowModelsProperty); }
            private set { SetValue(RowModelsProperty, value); }
        }
    }

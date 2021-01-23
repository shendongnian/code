    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RowModels = new ObservableCollection<RowModel>();
            for (int i = 0; i < 10; i++)
            {
                RowModels.Add(new RowModel(10));
            }
        }
        public static readonly DependencyProperty RowModelsProperty = DependencyProperty.Register("RowModels",
            typeof (ObservableCollection<RowModel>), typeof (MainWindow),
            new PropertyMetadata(default(ObservableCollection<RowModel>)));
        public ObservableCollection<RowModel> RowModels
        {
            get { return (ObservableCollection<RowModel>) GetValue(RowModelsProperty); }
            set { SetValue(RowModelsProperty, value); }
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }

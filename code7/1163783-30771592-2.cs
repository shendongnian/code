    public partial class MainWindow : Window
    {
        public ObservableCollection<Data> data { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            data = new ObservableCollection<Data>();
            data.Add(new Data() { Name = "Data1", Length = 1 });
            data.Add(new Data() { Name = "Data2", Length = 2 });
            this.DataContext = this;
        }
    }

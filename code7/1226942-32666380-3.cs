    public partial class MainWindow : Window
    {
        public ObservableCollection<Model> Source { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Source = new ObservableCollection<Model>
            {
                new Model {ID=1,Weight=3,Quantity=5,Length=11,Height=12,Width=0,X=1,Y=-1,Z=-1 },
                new Model {ID=2,Weight=21,Quantity=23,Length=0,Height=23,Width=11,X=-1,Y=-1,Z=-1 }
            };
            dataGrid.ItemsSource = Source;
        }
    }

    public partial class MainWindow : Window
    {
        ObservableCollection<myClass> my = new ObservableCollection<myClass>();
        public MainWindow()
        {
            InitializeComponent();
            dataGridView.DataContext = my;
            my.Add(new myClass { TId = 1, TChassisManufacturer = "Sony", ProjectStatusM = "Done" });
            my.Add(new myClass { TId = 2, TChassisManufacturer = "Apple", ProjectStatusM = "Doing" });
        }
    }
    class myClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int id;
        public int TId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("TId"));
            }
        }
        string name;
        public string TChassisManufacturer
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("TChassisManufacturer"));
            }
        }
        string status;
        public string ProjectStatusM
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ProjectStatusM"));
            }
        }
    }

        // Use ObservableCollection for store and preview data in view controls (see more MVVM)
        public ObservableCollection<Student> newStudents = new ObservableCollection<Student>(); 
        public MainWindow()
        {
            InitializeComponent();
            MyListBox.ItemsSource = newStudents; // MyListBox you may create in code or using XAML
        }

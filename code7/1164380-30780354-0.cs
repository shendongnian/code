        private ObservableCollection<Employee> displayEmp;
        public Form1()
        {
            InitializeComponent();
            displayEmp = new ObservableCollection<Employee>();
            // you need to assign DataSource only once
            listEmail.DataSource = displayEmp;
        }

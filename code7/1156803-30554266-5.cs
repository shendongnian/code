    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                BindData();
            }
    
            private void BindData()
            {
                var list = new List<Employee>
                {
                    new Employee {UserName = "Ali"},
                    new Employee {UserName = "Reza"},
                    new Employee {UserName = "Mohsen"},
                    new Employee {UserName = "Hasan"},
                    new Employee {UserName = "Hamed"}
                };
                ListView.ItemsSource = list;
            }
        }

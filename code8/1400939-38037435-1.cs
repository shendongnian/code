    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Emp { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Emp = new ObservableCollection<Employee>();
            Emp.Add(new Employee() { Name = "Anuj" });
            Emp.Add(new Employee() { Name = "Deepak" });
            Emp.Add(new Employee() { Name = "Aarti" });
            Emp[0].SubEmployee.Add(new Employee() { Name = "Tonu" });
            Emp[0].SubEmployee.Add(new Employee() { Name = "Monu" });
            Emp[0].SubEmployee.Add(new Employee() { Name = "Sonu" });
            Emp[2].SubEmployee.Add(new Employee() { Name = "Harsh" });
            Emp[2].SubEmployee.Add(new Employee() { Name = "Rahul" });
            Emp[2].SubEmployee.Add(new Employee() { Name = "Sachin" });
        }
    }

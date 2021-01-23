    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new PageContext();
        }
    }
    public class PageContext
    {
        private Employee _selectedEmployee;
        public PageContext()
        {
            this.ListOfEmployees = new ObservableCollection<Employee>();
            this.ListOfEmployees.Add(new Employee() { Name = "Voituron", Phone = "123.456.789" });
            this.ListOfEmployees.Add(new Employee() { Name = "Dubois", Phone = "147.258.369" });
        }
        public ObservableCollection<Employee> ListOfEmployees { get; set; }
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                Debugger.Break();
            }
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

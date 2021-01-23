     public partial class MainWindow : INotifyPropertyChanged
    {
        private ObservableCollection<MutableKeyValuePair<Employee, bool>> _employees;
        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<MutableKeyValuePair<Employee, bool>>
            {
                new MutableKeyValuePair<Employee, bool>(new Employee("Joakim"), false),
                new MutableKeyValuePair<Employee, bool>(new Employee("SoftwareIsFun"), false),
            };
        }
        public ObservableCollection<MutableKeyValuePair<Employee, bool>> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        public void UpdateDatabase()
        {
            foreach (var employee in Employees)
            {
                if (employee.Value)
                {
                    //DATABASE LOGIC HERE
                }
            }
        }
    }
    public class MutableKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public MutableKeyValuePair()
        {
            
        }
        public MutableKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

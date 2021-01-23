    public class TestViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<KeyValuePair<Employee, bool>> Employees
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
    
        public class Employee
        {
    
            public Employee(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
        }

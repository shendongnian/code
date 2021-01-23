    public class EmployeeDetailsViewModel
    {
            public EmployeeDetailsViewModel()
            {
                SelectAllCommand = new DelegateCommand<bool?>(HandleSelectAllCommand);
            }
    
            ObservableCollection<Employee> _employees = null;
            /// <summary>
            /// Collection bound to DataGrid
            /// </summary>
            public ObservableCollection<Employee> Employees { get => _employees; set { _employees = value; } }
    
            /// <summary>
            /// Command bound to SelectAll checkbox in XAML
            /// </summary>
            public ICommand SelectAllCommand { get; set; }
    
            private void HandleSelectAllCommand(bool? isChecked)
            {
                if (isChecked.HasValue)
                {
                    foreach (var employee in Employees)
                    {
                        employee.IsSelected = isChecked.Value;
                    }
                }
            }
    
            void PrepareData()
            {
                this.Employees = new ObservableCollection<Employee>()
                {
                    new Employee{Id=1, Name="abc", Salary=100000.00d},
                    new Employee{Id=2, Name="def", Salary=200000.00d},
                    new Employee{Id=3, Name="ghi", Salary=300000.00d},
                    new Employee{Id=4, Name="jkl", Salary=400000.00d}
                };
            }
    }

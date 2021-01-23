    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EmployeeViewModel> EmployeeList { get; set; }
        
        public ICommand ApplyChangesCommand;
        public EmployeesViewModel()
        {
            EmployeeList = new ObservableCollection<EmployeeViewModel>
            {
                new EmployeeViewModel(new Employee {EmpName = "Raj"}),
                new EmployeeViewModel(new Employee {EmpName = "Kumar"}),
                new EmployeeViewModel(new Employee {EmpName = "Bala"}),
                new EmployeeViewModel(new Employee {EmpName = "Manigandan"}),
                new EmployeeViewModel(new Employee {EmpName = "Prayag"}),
                new EmployeeViewModel(new Employee {EmpName = "Pavithran"}),
                new EmployeeViewModel(new Employee {EmpName = "Selva"})
            };
            ApplyChangesCommand = new DelegatingCommand(ApplyChanges);
        }
        private void ApplyChanges(object param)
        {
            foreach(var item in EmployeeList)
            {
                item.Model.IsChecked = item.IsChecked;
            }
        }
        
       ....
    }

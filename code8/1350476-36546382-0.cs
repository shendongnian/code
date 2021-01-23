    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EmployeeViewModel> EmployeeList { get; set; }
        private EmployeeViewModel _selectedItem;
        public EmployeeViewModel SelectedItem
        {
            get { return _selectedItem;}
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
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
            SelectedItem.Model.IsChecked = SelectedItem.IsChecked;
        }
        
       ....
    }

    private ICommand addEmployeeCommand;
    public ICommand AddEmployeeCommand { get { return addEmployeeCommand; } }
    public ObservableCollection<Employee> Employees { get; protected set; }
    private void AddEmployee() 
    {
        // Get the user input that's bound to the viewmodels properties
        var employee = Employee.Create(FirstName, LastName);
        // add it to the observable collection
        // Note: directly using model in your ViewModel for binding is a pretty bad idea, you should use ViewModels for your Employees too, like: 
        // Employee.Add(new EmployeeViewModel(employee));
        Employees.Add(employee);
        // add it to the repository
        this.employeeRepository.AddOrUpdate(employee);
    }
    // in constructor
    this.addEmployeeCommand = new DelegateCommand(AddEmployee, CanExecuteAddEmployee);

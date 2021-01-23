    public class ViewModel: INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
      EmployeeManagerXML emx = new EmployeeManagerXML();
      public ViewModel()
      {
        
      }
      private Void RefreshEmployeeList()
      {
          EmployeesView = new ListCollectionView(emx.getEmployeesList()) //this is an ObservableCollection
        {
            Filter = obj =>
            {
                var Employee = (Employee)obj;
                return SelectedEmployee != null && Employee.Name == SelectedEmployee.Name;
            }
        };
      }
      private Employee selectedEmployee;
      private ICollectionView _EmployeesView;
      public ICollectionView EmployeesView 
      {
           get { return _EmployeesView; }
           set
           {
               _EmployeesView = value;
               NotifyPropertyChanged();
           }
       }
      public Employee SelectedEmployee
      {
        get { return selectedEmployee; }
        set
        {
            if (selectedEmployee != value)
            {
                selectedEmployee = value;                
                NotifyPropertyChanged();
                RefreshEmployeeList();
            }
        }
    }

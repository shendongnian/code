    private ObservableCollection<Employee> employeeColl;
    public ObservableCollection<Employee> EmployeeColl
    {
       get { return employeeColl; }
       set
         {
           employeeColl = value;
           OnPropertyChanged("EmployeeColl");
         }
    }
    private void PopulateDataGrid()
    {
       employeeColl = new ObservableCollection<Employee>();
       for (int i = 0; i < 100; i++)
       {
         if(i%2==0)
            employeeColl.Add(new Employee() { ID = i, BackgroundOfRow = Brushes.CadetBlue});
         else
            employeeColl.Add(new Employee() { ID = i, BackgroundOfRow = Brushes.Green });
       }
    }

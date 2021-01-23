         private ObservableCollection<Employee> mysampleGrid=new ObservableCollection<Employee>();
        
                public ObservableCollection<Employee> MysampleGrid
                {
                    get { return mysampleGrid; }
                    set { mysampleGrid= value; }            
                }
    public void AddDataToDb()
        {            
    
            e.FirstName = FirstName;
            e.LastName = LastName;
            context.Employees.Add(e);
            context.SaveChanges();
            this.MySampleGrid = null;
    
            //Setting List to value from database after inserting into db
            var employees = context.Employees.Where(x => x.FirstName != null).ToList();
            foreach(var employee in employees)
            mysampleGrid.Add(employee);
        }

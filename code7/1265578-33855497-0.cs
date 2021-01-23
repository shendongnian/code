        public class Employee_list
        { 
            ObservableCollection<Employee> list = new ObservableCollection <Employee>();
    
            public ObservableCollection<Employee> List1
            {
                get { return list; }
            }
    
            public Employee_list()
            {
                List1.Add(new Employee("Alex", "Z"));
                List1.Add(new Employee("Alex", "K"));
            }
        }

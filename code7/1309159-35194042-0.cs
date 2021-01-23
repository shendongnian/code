    public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        public class Manager : Employee
        {
            public decimal Salary { get; set; }
            public T GetEmployee<T>()
            {
                var emp = Activator.CreateInstance<T>();
                var properties = emp.GetType().GetProperties();
                foreach (var property in properties)
                {
                    property.SetValue(emp, property.GetValue(this));
                }
                return emp;
            }
        }

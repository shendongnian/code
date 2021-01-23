     class Program
        {
            public class Company
            {
                public bool IsNone { get; set; }
            }
    
            public class Employee
            {
                public int LocationID { get; set; }
            }
    
            public class Location
            {
               public int ID { get; set; }
            }
    
            static void Main(string[] args)
            {
                var locationsToCompare = new List<Location> { new Location() { ID = 1 }, new Location() { ID = 2 } };
    
                var employees = new List<Employee> { new Employee() { LocationID = 1 }, new Employee { LocationID = 2 }, new Employee { LocationID = 1}, new Employee { LocationID = 5 } };
    
                var company = new Company();
    
                company.IsNone = false;
    
                var noneEmployees = company.IsNone
                              ? employees.Where(employee => locationsToCompare.Any(x => x.ID == employee.LocationID)).ToList()
                              : employees.Where(employee => locationsToCompare.All(x => x.ID != employee.LocationID)).ToList();
    
                var locationEmployees = employees.Except(noneEmployees).ToList();
    
            }
        }

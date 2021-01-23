        public class Employee
            {
                public virtual Guid Id { get; protected set; }
                public virtual string EmployeeNumber { get; set; }
                public virtual Country BirthCountry { get; set; }
                private ICollection<Assignment> _assignment = new List<Assignment>();
                public virtual ICollection<Assignment> Assignments
                {
                    get
                    {
                        return _assignment;
                    }
        
                    set
                    {
                        _assignment= value;
                    }
                }
            }
        
            public class Assignment
            {
                public virtual Guid Id { get; protected set; }
                public virtual DateTime BeginTime { get; set; }
                public virtual DateTime EndTime { get; set; }
                public virtual string Description{ get; set; } 
            }
        
            public class Country
            {
                public virtual Guid Id { get; protected set; }
                public virtual string Name { get; set; }
            }
        
       //Somewhere in your program      
       private void SaveAllChanges()
             {
                 _db = new EFContext();
                 var emp = new Employee { FirstName = "Emp Name", 
                     LastName = "Emp Last", EmployeeNumber = "XO1500"
                 };
                 emp.BirthCountry = new Country { Name = "Country1" };
                 emp.Assignment.Add(new Assignment{ BeginTime = DateTime.Now,EndTime=DateTime.Now.AddHours(1) });
                //Only employee is explicitly added to the context
                _db.Employees.Add(emp); 
                //All the objects in the employee graph will be inserted  
                _db.SaveChanges();
            }
        }

    namespace ConsoleApplication {
        internal class Program {
            private static void Main(string[] args) {
                Person p1 = new Person();
                p1.Validate(); // Exception
    
                Person p2 = new Person{Name = "Jack"};
                p2.Validate(); // OK
    
                Employee e1 = new Employee();
                e1.Validate(); // Exception
    
                Employee e2 = new Employee {Name = "John"};
                e2.Validate(); // Exception
    
                Employee e3 = new Employee { EmployeeNumber = 127};
                e3.Validate(); // Exception
    
                Employee e4 = new Employee {
                    Name = "Gill",
                    EmployeeNumber = 127
                };
                e4.Validate(); // OK
            }
        }
    
        public class Person {
            public string Name { get; set; }
    
            public virtual void Validate() {
                if (string.IsNullOrEmpty(Name)) {
                    throw new NotSupportedException("Name is not set");
                }
            }
        }
    
        public class Employee : Person {
            public int EmployeeNumber { get; set; }
    
            public override void Validate() {
                base.Validate();
    
                if (EmployeeNumber <= 0) {
                    throw new NotSupportedException("EmployeeNumber is not set");
    
                }
            }
        }
    }

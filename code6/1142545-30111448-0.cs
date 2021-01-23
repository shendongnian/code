    void Main() {
        var emp = new Employee {
            Id = 123,
            FirstName = "Billy",
            LastName = "Bobby", // lol, it's actually two first names
        };
    
        int originalHash = emp.GetHashCode();
    
        emp.FirstName = "Timmy";
    
        Console.WriteLine ("Original: {0}, Current: {1}", originalHash, emp.GetHashCode());
    }
    
    class Employee {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public override int GetHashCode() {
            return this.Id.GetHashCode()
                ^ this.FirstName.GetHashCode()
                ^ this.LastName.GetHashCode();
        }
    
        public override bool Equals(object other) {
            var otherEmployee = other as Employee;
            return otherEmployee != null
                && otherEmployee.Id == this.Id
                && otherEmployee.FirstName == this.FirstName
                && otherEmployee.LastName == this.FirstName;
        }
    }

    void Main()
    {
        List<Employee> previous = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "1" },
            new Employee() { Id = 2, Name = "2" },
            new Employee() { Id = 6, Name = "6" },
            new Employee() { Id = 8, Name = "8" }
        };
    
        List<Employee> latest = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "1" },
            new Employee() { Id = 3, Name = "3" },
            new Employee() { Id = 5, Name = "5" },
            new Employee() { Id = 6, Name = "6" }
        };
    
        var result = new List<EmployeeStatus>();
        int previousIndex = 0;
        int latestIndex = 0;
        foreach (var section in Diff.Calculate(previous, latest))
        {
            if (section.Equal)
            {
                for (int index = 0; index < section.Length1; index++)
                {
                    result.Add(new EmployeeStatus { Action = "NoChange", Employee = previous[previousIndex] });
                    previousIndex++;
                    latestIndex++;
                }
            }
            else
            {
                for (int index = 0; index < section.Length1; index++)
                {
                    result.Add(new EmployeeStatus { Action = "Removed", Employee = previous[previousIndex] });
                    previousIndex++;
                }
                for (int index = 0; index < section.Length2; index++)
                {
                    result.Add(new EmployeeStatus { Action = "Added", Employee = latest[latestIndex] });
                    latestIndex++;
                }
            }
        }
        result.Dump();
    }
    
    public class Employee : IEquatable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public override int GetHashCode() { return Id * 23 + (Name == null ? 0 : Name.GetHashCode()); }
        public bool Equals(Employee other)
        {
            if (other == null) return false;
            if (ReferenceEquals(other, this)) return true;
    
            return Id == other.Id && Name == other.Name;
        }
        public override bool Equals(object other)
        {
            return Equals(other as Employee);
        }
    }
    
    public class EmployeeStatus
    {
        public string Action { get; set; }
        public Employee Employee { get; set; }
    }

    class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
    class EmpEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x.Id == y.Id && x.Name == y.Name)
                return true;
            else
                return false;
        }
        
        public int GetHashCode(Employee obj)
        {
            int hCode = obj.Id;
            return hCode.GetHashCode();
        }
    }

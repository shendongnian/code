    public class Employee : IComparable<Employee>
    {
        public string EmpName { get; set; }
        public bool IsChecked { get; set; }
    
        public int CompareTo(Employee other)
        {
            if (other == null) return -1;//if you want nulls to be considered and put at the top of the list
            return this.EmpName.CompareTo(other.EmpName);
        }
    }

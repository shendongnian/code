    public class Emp_Details : IEnumerable
        {
            public List<Employee> lstEmployee { get; set; }
    
    
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException("You must implement this");
            }
        }

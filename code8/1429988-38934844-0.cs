    public class EmployeeService
    {
        public EmployeeDto GetEmployee(int id)
        {
            using(DbContext db=new DbContext())
            {
                return db.Employees.Select(e =>
                    new EmployeeDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Department = e.Department.Name
                    }).First(e => e.Id == id);
            }
        }
    }
    public class EmployeeDto
    {
        public int Id { get;set;}
        public string Name { get;set;}
        public string Department { get;set;}
    }

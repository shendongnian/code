    public class EmpModel
    {
        EmployeeEntities empdb = new EmployeeEntities();
       
        public List<EMPTABLE> GetEmployees()
        {
           return empdb.FETCHEMPLOYEES().ToList();  
        }
        public EMPTABLE GetEmployee(int? id)
        {
            return empdb.FETCHEMPLOYEE(id).ToList().Single();
        }
    }

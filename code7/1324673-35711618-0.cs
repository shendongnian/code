    public class EmployeeNameService
    {
       readonly IEmployeeRepository _repo;
       public EmployeeNameService(IEmployeeRepsitory repo)
       {
          _repo=repo;
       }
       public string GetEmployeeName(int empID)
       {
          var emp = _repo.GetByID(empID);
          var name = emp.GetEmployeeName();//does some crazy logic based on the Employee state or whatever.
          return name;
       }
    }

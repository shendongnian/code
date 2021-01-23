    public interface IEmployeeRepository
    {
        Employee GetById(string id);
    }
    public class EmployeeRepository: IEmployeeRepository
    {
        public Employee GetById() {//access to OData}
    } 
 

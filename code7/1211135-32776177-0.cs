    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        #region Properties
        [OperationContract]
        string AddEmployeeDetails(Employee Employee);
                
        [OperationContract]
        List<Employee> GetEmployeeDetails(int PageNumber,int PageSize,string SortColumn,string SortOrder);
        [OperationContract]
        string UpdateEmployeeDetails(Employee Employee);
        #endregion
    }
}
    enter code here:EmployeeServices.svc

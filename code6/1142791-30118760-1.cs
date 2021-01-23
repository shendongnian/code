    public class StaffService
    {
        private IEmployeeRepository employeeRepository;
        private IWorkLogRepository workLogRepository;
        private IUnitOfWorkFactory uowFactory;
    
        // inject dependencies
        
        public void Fire(Employee employee)
        {
            using(var uow = uowFactory.SartNew())
            {
                workLogRepository.DeleteByEmployee(employee.Id);
                employeeRepository.Delete(employee.Id);
                uow.Commit();
            }
        }
    }

    public class DepartmentDataServices : IDepartmentDataServices
    {
        private readonly IDepartmentUnitOfWork m_DepartmentUnitOfWork;
    
        public DepartmentDataServices(IDepartmentUnitOfWork uow)
        {
            m_DepartmentUnitOfWork = uow;
        }
    
        Public List<Product> GetProductList()
        {
            return m_DepartmentUnitOfWork.GetProductList();
        }
    }

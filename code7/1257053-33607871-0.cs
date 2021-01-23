    public class BaseController<TEntity, TViewModel>
    {
        private readonly IService<TEntity, TViewModel> _service;
    
        public BaseControlle(IService<TEntity, TViewModel> service)
        {
            _service = service;
        }
    }
    public class StaffController : BaseController<IStaff, IStaffViewModel>
    {
        public StaffController(IStaffService service) : base(service)
        {
        }
    }

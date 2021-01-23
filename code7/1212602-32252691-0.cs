    // Addresses API 
    public class AddressController : ApiController
    {
        private readonly IRepository<Address> _repository;
        public AddressController(IRepository<Address> repository)
        {
            _repository = repository;
        }
        [BasicAuthorize]
        public IList<Address> GetList()
        {
            return _repository.GetAll();
        }
    }
    // Constomer information API
    public class CustomerInformationController : ApiController
    {
        private readonly IRepository<CustomerInformation> _repository;
        public CustomerInformationController(IRepository<CustomerInformation> repository)
        {
            _repository = repository;
        }
        [BasicAuthorize]
        public IList<CustomerInformation> GetList()
        {
            return _repository.GetAll();
        }
    }

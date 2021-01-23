    using IEFRepository;
    class ProductController : ApiController 
    {
        IEFRepository<Product> _prodRepo;
        public ProductController(
            IEFRepository<Product> prodRepo
        )
        {
            _prodRepo = prodRepo;
        }
        [HttpGet]
        public List<Product> GetProducts() => _prodRepo.Get().ToList();
    }

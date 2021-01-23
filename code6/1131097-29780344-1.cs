    public class TokenController : ApiController
    {
        private readonly ITokenRepository _repository;
        private readonly ILogger _logger;
        public TokenController(ITokenRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public HttpResponseMessage Token()
        {
            ....
            _logger.Info(string.Format("Customer {0} autenticated", customerId));
            ....
        }
    }

    public class ServerController : Controller
    {
        private readonly Repository _repository;
        private readonly APIRepository _apiRepository;
        public ServerController(Repository repository, APIRepository apiRepository)
        {
            _repository = repository;
            _apiRepository = apiRepository;
        }

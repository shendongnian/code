    public class HomeController : Controller  {
        private IDocumentRepository _repository;
        public HomeController(IDocumentRepository repository) { 
            _repository = repository;
        }
    }

    public class ExecutiveController : Controller
    {
        private IExecutiveRepository executiveRepository;
        private IUserRepository userRepository;
        private IExecutiveSectionRepository executiveSectionRepository;
        private IExecutiveSectionMappingRepository executiveSectionMappingRepository;
        private IContentRepository contentRepository;
    
        public ExecutiveController(
             IExecutiveRepository executiveRepository,
             IUserRepository userRepository,
             IExecutiveSectionRepository executiveSectionRepository,
             IExecutiveSectionMappingRepository executiveSectionMappingRepository,
             IContentRepository contentRepository)
        {
    
        }
    
        public ActionResult Index(int id)
        {
            // Use one of your dependencies...
            var executive = this.executiveRepository.GetExecutiveById(id);
        }
    }

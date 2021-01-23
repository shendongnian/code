    public class ExecutiveController : Controller
    {
        private IExecutiveRepository ExecutiveRepository;
        private IUserRepository UserRepository;
        private IExecutiveSectionRepository ExecutiveSectionRepository;
        private IExecutiveSectionMappingRepository ExecutiveSectionMappingRepository;
        private IContentRepository ContentRepository;
    
        public ExecutiveController(
             IExecutiveRepository executiveRepository,
             IUserRepository userRepository,
             IExecutiveSectionRepository executiveSectionRepository,
             IExecutiveSectionMappingRepository executiveSectionMappingRepository,
             IContentRepository contentRepository)
        {
    
             // Set the field values
    		 this.ExecutiveRepository = executiveRepository,
             this.UserRepository = userRepository,
             this.ExecutiveSectionRepository = executiveSectionRepository,
             this.ExecutiveSectionMappingRepository = executiveSectionMappingRepository,
             this.ContentRepository = contentRepository;
        }
    
        public ActionResult Index(int id)
        {
            // Use one of your dependencies...
            var executive = this.executiveRepository.GetExecutiveById(id);
        }
    }

    public class ExecutiveController : Controller
    {
        [Inject]
        public IExecutiveRepository executiveRepository { get; set; }
        [Inject]
        public IUserRepository userRepository { get; set; }
        [Inject]
        public IExecutiveSectionRepository executiveSectionRepository { get; set; }
        [Inject]
        public IExecutiveSectionMappingRepository executiveSectionMappingRepository { get; set; }
        [Inject]
        public IContentRepository contentRepository { get; set; }
    
        public ExecutiveController()
        {
    
        }
    
        public ActionResult Index(int id)
        {
            // Use one of your dependencies...
            var executive = this.executiveRepository.GetExecutiveById(id);
        }
    }

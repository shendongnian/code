    using AutoMapper;
    using ...
    
    namespace ***Your Namespace***
    {
        public class ApplicationsController : BaseController
        {
            [FromServices]
            private IMapper _mapper { get; set; }
    
            [FromServices]
            private IApplicationRepository _applicationRepository { get; set; }
    
            public ApplicationsController(
                IMapper mapper,
                IApplicationRepository applicationRepository)
            {
                _mapper = mapper;
                _applicationRepository = applicationRepository;
            }
    
            // GET: Applications
            public async Task<IActionResult> Index()
            {
                IEnumerable<Application> applications = await _applicationRepository.GetForIdAsync(...);
    
                if (applications == null)
                    return HttpNotFound();
    
                List<ApplicationViewModel> viewModel = _mapper.Map<List<ApplicationViewModel>>(applications);
    
                return View(viewModel);
            }
    
            ...
    }

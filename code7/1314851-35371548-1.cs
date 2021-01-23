    internal class ProjectService : IProjectService {
        private readonly IMapper _mapper;
        public ProjectService(IMapper mapper) {
             _mapper = mapper;
        }
        public ProjectCreate Get(string key) {
            var project = GetProjectSomehow(key);
            return _mapper.Map<Project, ProjectCreate>(project);
        }
    }
 

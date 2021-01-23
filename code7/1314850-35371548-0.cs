    internal class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Project, ProjectCreate>();
        }
    }

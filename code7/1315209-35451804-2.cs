    using AutoMapper;
    using YourModels;
    using YourViewModels;
    
    namespace YourNamespace
    {
        public class AutoMapperProfileConfiguration : Profile
        {
            protected override void Configure()
            {
                CreateMap<Application, ApplicationViewModel>();
                CreateMap<ApplicationViewModel, Application>();
                ...
            }
        }
    }

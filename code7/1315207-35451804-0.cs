    using AutoMapper;
    using ***YourModels***
    using ***Your ViewModels***
    
    namespace ***Your Namespace***
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

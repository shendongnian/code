    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DBO.User, ViewModels.UserViewModel>();
        }
    }
    
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModels.UserViewModel, DBO.User>();
        }
    }
    // initialize your mapper by provided profiles
    Mapper.Initialize(x =>
    {
      x.AddProfile<DomainToViewModelMappingProfile>();
      x.AddProfile<ViewModelToDomainMappingProfile>();
    });
    
    Mapper.AssertConfigurationIsValid();

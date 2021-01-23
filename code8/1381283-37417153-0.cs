    public class DomainToViewModelMappingProfile : Profile
    {
     public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }
    protected override void Configure()
    {
        Mapper.CreateMap<DBO.User, ViewModels.UserViewModel>();
    }
    }

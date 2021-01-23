    // in this case just call CreateMap from Profile class - its the same as CreateMap on `cfg`
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<DBO.User, ViewModels.UserViewModel>();
        }
    }
    
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ViewModels.UserViewModel, DBO.User>();
        }
    }
    // initialize you mapper config
    var config = new MapperConfiguration(cfg => {
        cfg.AddProfile<DomainToViewModelMappingProfile>();
        cfg.AddProfile<ViewModelToDomainMappingProfile>();
    });
    
    // and then use it
    var mapper = config.CreateMapper();
    // or
    var mapper = new Mapper(config);
    var dest = mapper.Map<Source, Dest>(new Source());

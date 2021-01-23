    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            // you should not to call Initialize method inside your profiles.
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ViewModels.UserViewModel, DBO.User>();
            });
        }
    }

    public static void Initialise(IContainer container)
    {
        var type = typeof(Profile);
        var profiles = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .SelectMany(a => a.GetTypes())
                                .Where(t => type.IsAssignableFrom(t) && type != t)
                                .Select(container.GetInstance)
                                .Cast<Profile>()
                                .ToList();
        Mapper.Initialize(c =>
            {
                profiles.ForEach(c.AddProfile);
                c.ConstructServicesUsing(container.GetInstance);
            });
    }
    public class MyProfile : Profile
    {
        private readonly IContainer _container;
    
        public MyProfile(IContainer container)
        {
            _container = container;
        }
    
        private static void Configure()
        {
            Mapper.CreateMap<Entity, Model>()
                .ForMember(d => d.ImageUrl, o => o.ResolveUsing<ImageUrlResolver>().ConstructedBy(() => new ImageUrlResolver(_container, "150x150"))
        }
    }

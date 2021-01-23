    public class PeopleEfProvider : IPeopleDbContext
    {
        private static Lazy<IMappingEngine> MappingEngineInit = new Lazy<IMappingEngine>(() => {
            Mapper.Initialize(mapperConfiguration =>
            {
                mapperConfiguration.AddProfile(new PeopleEfEntityProfile());
            });
            Mapper.AssertConfigurationIsValid();
            return Mapper.Engine;
        });
        public IMappingEngine MappingEngine { get; set; }
        public DatabaseHelpersRepo DatabaseHelpersRepo { get; set; }
        public PeopleDataContext DataContext { get; set; }
        public PeopleEfProvider(PeopleDataContext dataContext = null, IMappingEngine mappingEngine = null)
        {
            DataContext = dataContext ?? new PeopleDataContext();
            MappingEngine = mappingEngine ?? MappingEngineInit.Value;
            DatabaseHelpersRepo = new DatabaseHelpersRepo(DataContext, MappingEngine);
        }
    }

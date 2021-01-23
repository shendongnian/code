    class Program
    {
        static void Main(string[] args)
        {
            dynamic newObject = new NewObject();
            var objectToCopy = new ObjectToCopy();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });
            var mapper = config.CreateMapper();
            mapper.Map(objectToCopy, newObject);
            // newObject.LU_Ignore = "Original value"
            // newObject.DoNotIgnore = "New value"
        }
    }
    class MyProfile : Profile
    {
        protected override void Configure()
        {
            CreateMissingTypeMaps = true;
            ShouldMapProperty = p => !p.Name.StartsWith("LU"); // this is the correct way to get the property name
        }
    }
    class ObjectToCopy
    {
        public string LU_Ignore { get; set; } = "New value";
        public string DoNotIgnore { get; set; } = "New value";
    }
    class NewObject
    {
        public string LU_Ignore { get; set; } = "Original value";
        public string DoNotIgnore { get; set; } = "Original value";
    }
Something seems goofy about how configurations are applied to the Mapper created form the mapper.CreateMapper call. I'm looking into it to see if I can find out more information and will update this answer if I find anything.

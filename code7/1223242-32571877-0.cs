    public class CompositeCustomizationsAttribute : AutoDataAttribute
    {
        public CompositeCustomizationsAttribute(params Type[] customizationTypes)
        {
            foreach (var type in customizationTypes)
            {
                var customization = (ICustomization)Activator.CreateInstance(type);
                Fixture.Customize(customization);
            }
        }
    }
    public class InMemoryRepositoryCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<IRepository>(() => CreateRepository(fixture));
        }
        protected IRepository CreateRepository()
        {
            var data = Fixture.CreateMany<ISomeOtherData>().ToList();
            var repository = new InMemoryDAL.Repository();
            repository.Insert(data);
            return repository;
        }
    }
    public class SomeOtherDataCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<ISomeOtherData>(() => CreateData(fixture));
        }
        protected ISomeOtherData CreateData()
        {
            string test = Fixture.Create<string>();
            var data = (new SomeOtherDataFactory()).Create(test);
            return data;
        }
    }

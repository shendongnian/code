    public class CheckRegistrations
    {
        [Test]
        public void Should_Have_Register_Types()
        {
            //Arrange
            var typesToCheck = new List<Type>
            {
                typeof (ISomeMathServiceA),
                typeof (ISomeMathServiceB)
            };
            //Act
            var typesRegistered = this.GetTypesRegisteredInModule(new IoCModule());
            //Arrange
            Assert.AreEqual(typesToCheck.Count, typesRegistered.Count());
            foreach (var typeToCheck in typesToCheck)
            {
                Assert.IsTrue(typesRegistered.Any(x => x == typeToCheck), typeToCheck.Name + " was not found in module");
            }
        }
        private IEnumerable<Type> GetTypesRegisteredInModule(Module module)
        {
            IComponentRegistry componentRegistry = new ComponentRegistry();
            module.Configure(componentRegistry);
            var typesRegistered =
                componentRegistry.Registrations.SelectMany(x => x.Services)
                    .Cast<TypedService>()
                    .Select(x => x.ServiceType);
            return typesRegistered;
        }
    }

    public class FooCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                SpecimenBuilderNodeFactory.CreateTypedNode(
                    typeof(Foo),
                    new Postprocessor(
                        new MethodInvoker(
                            new ModestConstructorQuery()),
                        new CompositeSpecimenCommand(
                            new AutoPropertiesCommand(),
                            new UniqueIDsOnFooCommand()))));
        }
    }

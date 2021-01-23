    public class AllPersonsAreNamedBen : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Person>(composer =>
                composer.With(p => p.Name, "Ben"));
        }
    }
    public class AllPersonsAreBornIn1900 : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Person>(composer =>
                composer.With(p => p.DateOfBirth, new DateTime(1900, 1, 1)));
        }
    }

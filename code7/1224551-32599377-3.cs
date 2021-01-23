    internal class NumericSequenceCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new NumericSequenceGenerator());
        }
    }

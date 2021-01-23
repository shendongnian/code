    public class SamplePocoSubstituteCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => Substitute.For<SamplePoco>());
        }
    }
    [TestMethod]
    public void SampleTest()
    {
        var fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization())
                                       .Customize(new SamplePocoSubstituteCustomization());
        var substitute = fixture.Create<SamplePoco>();
        var formattedString = fixture.Create<string>();
        substitute.GetFormattedString().Returns(formattedString);
        // ... test goes here
    }

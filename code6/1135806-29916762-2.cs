    public class DependencyAttribute : Attribute
    {
    }
    public class TestClass
    {
        [Dependency]
        public string With { get; set; }
        public string Without { get; set; }
    }
    [Fact]
    public void OnlyPropertiesWithDependencyAttributeAreResolved()
    {
        // Fixture setup
        var fixture = new Fixture
        {
            Customizations = {new PropertyBuilder()}
        };
        // Exercise system
        var sut = fixture.Create<TestClass>();
        // Verify outcome
        Assert.NotNull(sut.With);
        Assert.Null(sut.Without);
    }

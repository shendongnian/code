    public class FakeServiceCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Mock<IService>>(composer =>
                composer.Do(fake =>
                    fake.Setup(service => service.Create<Something>())
                        .ReturnsUsingFixture(fixture);
        }
    }

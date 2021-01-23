    internal class TestConventions : AutoDataAttribute
    {
        internal TestConventions()
            : base(
                new Fixture().Customize(
                    new AutoMoqCustomization()))
        {
        }
    }

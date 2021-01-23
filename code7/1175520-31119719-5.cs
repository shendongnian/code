    internal class TestConventionsAttribute : AutoDataAttribute
    {
        internal TestConventionsAttribute()
            : base(
                new Fixture().Customize(
                    new AutoMoqCustomization()))
        {
        }
    }

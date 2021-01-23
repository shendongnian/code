    internal class MyAutoDataAttribute : AutoDataAttribute
    {
        internal MyAutoDataAttribute()
            : base(
                new Fixture().Customize(
                    new CompositeCustomization(
                        new MyCustomization())))
        {
        }
        private class MyCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize<Thing>(x => x.With(y => y.UserId, 1));
            }
        }
    }

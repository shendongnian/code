    public class MyProjectAutoDataAttribute : AutoDataAttribute
    {
        public MyProjectAutoDataAttribute() : base(
            new Fixture().Customize(new TestConventions()))
        {
        }
    }

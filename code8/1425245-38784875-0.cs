    public class VisibilityAttribute : Attribute
    {
        public Visibility Visibility { get; private set; }
        public VisibilityAttribute(Visibility visibility)
        {
            this.Visibility = visibility;
        }
    }

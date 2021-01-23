    public static class Icons
    {
        public enum Type
        {
            IdeaIcon = 1,
            BellIcon =2
        }
        public static Icon Get(Type type)
        {
            return IconCollection.Single(icon => icon.Type == type);
        } 
        static IEnumerable<Icon> IconCollection
        {
            get
            {
                return new List<Icon>
                {
                    new Icon(Type.IdeaIcon, "Idea Icon", "icon idea-icon"),
                    new Icon(Type.BellIcon, "Bell Icon", "icon bell-icon"),
                };
            }
        }
        public class Icon
        {
            public Icon(Type type, string description, string cssClass)
            {
                Type = type;
                Description = description;
                CssClass = cssClass;
            }
            public Type Type { get; private set; }
            public string Description { get; private set; }
            public string CssClass { get; private set; }
        }
    }

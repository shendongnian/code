    [AttributeUsage(AttributeTargets.All, Inherited = true)]
        public class DescriptionAttribute : Attribute
        {
            private readonly string _title;
            public string Title
            {
                get { return _title; }
            }
    
            public DescriptionAttribute(string title)
            {
                _title = title;
            }
        }
    
        public static class Extensions
        {
            public static string GetDisplayName(this MemberInfo target)
            {
                return target.GetCustomAttributes(typeof(DescriptionAttribute), true)
                    .Cast<DescriptionAttribute>().Select(d => d.Title)
                    .SingleOrDefault() ?? target.Name;
            }
        }

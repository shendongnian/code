    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string menuPath)
        {
            MenuPath = menuPath;
        }
        public string MenuPath { get; }
    }

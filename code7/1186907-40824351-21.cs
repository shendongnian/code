    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public string Name { get; }
        public PermissionAttribute(string name) : base("Permission")
        {
            Name = name;
        }
    }

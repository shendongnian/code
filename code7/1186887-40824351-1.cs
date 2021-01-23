    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public PermissionAttribute(string name) : base("Permission")
    {
        public string Name { get; }
        public PermissionAttribute(string name)
        {
            Name = name;
        }
    }

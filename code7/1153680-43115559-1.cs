    public sealed class DbColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public DbColumnAttribute(string name)
        {
            Name = name;
        }
    }

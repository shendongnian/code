    public class Category
    {
        private class UnassignedCategory : Category
        {
            public UnassignedCategory() : base("") { }
        }
        private static readonly UnassignedCategory _unassigned = new UnassignedCategory();
        public static Category Unassigned 
        { 
            get { return _unassigned; }
        }
        public Category(string name) 
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public bool IsAssigned 
        {
            get { return ReferenceEquals(this, _unassigned); }
        }
    }

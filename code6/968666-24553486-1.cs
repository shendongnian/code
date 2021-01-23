    [Table("Parent")]
    public partial class Parent
    {
        private List<Child> _children;
        public Parent()
        {
            _children = new List<Child>();
        }
        // other properties, etc.
        public List<Child> Children
        {
            get { return _children; }
            set { _children = value; }
        }
    }

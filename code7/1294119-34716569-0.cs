    public class ParentViewModel
    {
        public ChildViewModel_A Child_A { get; } = new ChildViewModel_A
        {
            IntProperty = 100
        };
        public ChildViewModel_B Child_B { get; } = new ChildViewModel_B
        {
            StringProperty = "Hello, world!"
        };
    }
    public class ChildViewModel_A
    {
        public int IntProperty { get; set; }
    }
    public class ChildViewModel_B
    {
        public string StringProperty { get; set; }
    }

    public class ChildClass
    {
        public virtual ParentBase Parent { get; set; }
    
        // beware of proxies when casting... this may not work like this
        public Parent1Class Parent1 { get { return Parent as Parent1Class; } }
        public Parent2Class Parent2 { get { return Parent as Parent2Class; } }
        .
        .
        .
    }

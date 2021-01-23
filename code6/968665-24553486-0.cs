    [Table("Parent")]
    public partial class Parent
    {
        public Parent()
    {
        List<Child> _Children = new List<Child>();
    }
     //Other Properties etc
     public List<Child> Children
    {
        get {return _Children;}
        set {_Children = value;}
    }
    }

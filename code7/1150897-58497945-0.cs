    class Program
    {
        static void Main(string[] args)
        {
            ParentClass obj = new ParentClass();
            obj.ChildDetails.Clear();
            obj.ChildDetails.AddRange();
            obj.LstNames.Clear();
            obj.LstNames.AddRange();
        }
    }
    public class ChildClass
    { }
    public class ParentClass
    {
        private readonly ICollection<ChildClass> _ChildClass;
        public ParentClass()
        {
            _ChildClass = new HashSet<ChildClass>();
        }
        public virtual ICollection<ChildClass> ChildDetails => _ChildClass;
        public IList<string> LstNames => new List<string>();
    }
    

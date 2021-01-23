    class Program
    {
        static void Main(string[] args)
        {
            var m1=new TreeModel() { ID=1 };
            var m2=new TreeModel(m1) { ID=2 };
            var m21=new TreeModel(m2) { ID=21 };
            var m22=new TreeModel(m2) { ID=22};
            var m3=new TreeModel(m1) { ID=3 };
            var item=m1.RecursiveFind((p) => p.ID==22);
            var parent=item.Parent;
            // parent.ID == 2
            var root=item.Root;
            // root.ID == 1;
        }
    }
    public class TreeModel : Tree<TreeModel>
    {
        public int ID { get; set; }
        public TreeModel() { }
        public TreeModel(TreeModel parent) : base(parent) { }
    }
    public class Tree<T> where T : Tree<T>
    {
        protected Tree() : this(null) { }
        protected Tree(T parent)
        {
            Parent=parent;
            Children=new List<T>();
            if(parent!=null)
            {
                parent.Children.Add(this as T);
            }
        }
        public T Parent { get; set; }
        public List<T> Children { get; set; }
        public bool IsRoot { get { return Parent==null; } }
        public T Root { get { return IsRoot?this as T:Parent.Root; } }
        public T RecursiveFind(Predicate<T> check)
        {
            if(check(this as T)) return this as T;
            foreach(var item in Children)
            {
                var result=item.RecursiveFind(check);
                if(result!=null)
                {
                    return result;
                }
            }
            return null;
        }
    }

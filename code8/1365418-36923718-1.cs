    public class MyClass
    {
        private readonly HashSet<string> _referencedColumns;
    
        public ICollection<string> ReferencedColumns { 
            get { return new MyReadOnlyCollection<string>(_referencedColumns); }
        }
        //...

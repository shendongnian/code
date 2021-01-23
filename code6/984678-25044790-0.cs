    public class ExtendedTypes : List<ExtendedType>
    {
        public ExtendedTypes (IEnumerable<ExtendedType> items) : base(items)
        {}
    
        public ExtendedTypes Active
        {
            get { return new ExtendedTypes(this.Where(x => x.IsActive)); } 
        }
    }

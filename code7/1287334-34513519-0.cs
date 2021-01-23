    public class DestinationClass
    {
        private IList<string> strings;
    
        public IList<string> Strings { get { return this.strings; } }
    
        public DestinationClass() : this(new List<string>()) { }
        public DestinationClass(IList<string> strs) {
            strings = strs.ToList(); // clone it
        }
        //...
    }

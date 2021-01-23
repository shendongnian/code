    public class DestinationClass
    {
        private IList<string> strings;
    
        public IList<string> Strings { get { return this.strings; } }
    
        public DestinationClass(List<string> strings = null)
        { 
            this.strings = strings ?? new List<string>();
        }
       //...
    }

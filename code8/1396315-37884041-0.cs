    class SomeWeirdClass
    {
        private bool sortApplied = false;
        private List<int> elements;
    
        public IList<int> Elements
        {
            get
            {
                if(sortApplied)
                {
                    elements.Sort();
                    sortApplied = false;
                }
    
                return elements;
            }
        }
    
        public SomeWeirdClass(IEnumerable<int> elements)
        {
            this.elements = elements.ToList();
        }
    
        public SortedWeirdClass Sort()
        {
            sortApplied = true;
    
            return new SortedWeirdClass(this);
        }
    
        public class SortedWeirdClass
        {
            SomeWeirdClass parent;
    
            internal SortedWeirdClass(SomeWeirdClass parent)
            {
                this.parent = parent;
            }
    
            public static implicit operator SomeWeirdClass(SortedWeirdClass sorted)
            {
                sorted.parent.sortApplied = false;
    
                var elementCopy = new int[sorted.parent.elements.Count];
                sorted.parent.elements.CopyTo(elementCopy);
    
                var result = new SomeWeirdClass(elementCopy);
                result.Sort();
    
                return result;
            }
        }    
    }

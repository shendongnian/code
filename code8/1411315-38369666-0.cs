    abstract class ReferenceManager3
    {
        // Static list containing a reference to all Typed Lists
        protected static List<IList> _masterList = new List<IList>();
    }
    
    class ReferenceManager3<T> : ReferenceManager3 where T : class //IReferenceTracking
    {
    
        // Object Typed List
        private List<T> _list = null;
    
        public ReferenceManager3()
        {
            // Create the new Typed List
            _list = new List<T>();
    
            // Add it to the Static Master List
            _masterList.Add(_list); // <<< break here on the second call.
        }
    }

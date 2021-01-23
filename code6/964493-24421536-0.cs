    public class Class1
    {
        // Here's your object to lock on
        private readonly object _lockObject = new object();
        // NOTE: made this private to control how it is exposed!
        private List<Resource> Class1Resources = null;
        public Class1()
        {
            // subscribe to external app event, with callback = ExternalAppCallback
        }
        private void ExternalAppCallback(List<Resource> updatedResourceList)
        {
            // Setting a reference is always atomic, no need to lock this
            Class1Resources = new List<Resource>(updatedResourceList);
        }
        // Your new method to expose the list in a thread-safe manner
        public List<Resource> GetResources()
        {
            lock (_lockObject)
            {
                // ToList() makes a copy of the list versus maintaining the original reference
                return Class1Resources.ToList();
            }
        }
        public List<Resource> GetResourcesByCriteria1(string criteria1)
        {
            lock (_lockObject)
            {
                return Class1Resources.Where(r => r.Criteria1 == criteria1).ToList();
            }
        }
        public List<Resource> GetResourcesByCriteria2(string criteria2)
        {
            lock (_lockObject)
            {
                return Class1Resources.Where(r => r.Criteria2 == criteria2).ToList();
            }
        }
    }

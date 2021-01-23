    public IEnumerable<string> ExcludedFileExtensions
    {
        get
        {
            var current = m_ExcludedFileExtensions;
            // NOTES: This is only needed if 
            // (1) there are other ways the contents of the 
            //     'm_ExcludedFileExtensions' list could change
            //      than through the below set method. 
            // (2) you want to prevent clients casting the result 
            //     to a List<string>
            return current.ToArray(); // client cannot add / remove.
            // OTHERWISE, just do this:
            // return current;
        }
        set
        {
            // Personally I find a setter replacing the entire contents
            // rather odd, but then again I don't know your use case.
            var newList = value.ToList();
            m_ExcludedFileExtensions = newList; 
        }
    }

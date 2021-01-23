    public IEnumerable<string> ExcludedFileExtensions
    {
        get
        {
            var current = m_ExcludedFileExtensions;
            return current;
            // If it could change/you want to prevent client casts:
            // return an immutable copy.
            // return current.ToArray();
        }
        set
        {
            // Personally I find a setter replacing the entire contents
            // rather odd, but then again I don't know your use case.
            var newList = value.ToList();
            m_ExcludedFileExtensions = newList; 
        }
    }

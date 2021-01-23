    public sealed class TestCollection<T> : ICollection<T>
       where T : AbstractBaseClass, new()
    {
        private List<T> Tests { get; } = new List<T>();
        
        public T this[int index] => Tests[index];
    
        public void Add(T test) => Tests.Add(test);
    
        // Rest of ICollection<T> members
        public void NewAt(int testIndex) => Tests[testIndex].Insert(testIndex, new T());
    } 

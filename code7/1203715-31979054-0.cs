    public class TestObject
    {
        /// <summary>
        /// Keep a list of all the instances of TestObject's that are created.
        /// </summary>
        internal static Dictionary<Guid, TestObject> _collections = new Dictionary<Guid, TestObject>();
        /// <summary>
        /// An ID to uniquely identify an instance of a TestObject
        /// </summary>
        public Guid ID { get; private set; }
        /// <summary>
        /// A reference to the collection which will be set in the constructor
        /// </summary>
        public TestObjectCollection TestObjects { get; private set; }
        public TestObject()
        {
            //generate the unique id
            this.ID = Guid.NewGuid();
            this.TestObjects = new TestObjectCollection();
            //add this testobject to the List of test objects.
            _collections.Add(this.ID, this);
        }
        /// <summary>
        /// Destructor, kill the TestObject from the list of TestObject's.
        /// </summary>
        ~TestObject()
        {
            if (_collections.ContainsKey(this.ID))
            {
                _collections.Remove(this.ID);
            }
        }
    }
    public class TestObjectCollection : IEnumerable<TestObject>
    {
        private List<TestObject> _testObjects = new List<TestObject>();
        public Guid ID { get; private set; }
        public TestObject this[int i]
        {
            get
            {
                return _testObjects[i];
            }
        }
        private TestObject _Parent = null;
        public TestObject Parent
        {
            get
            {
                if (_Parent == null)
                {
                    _Parent = TestObject._collections.Values.Where(p => p.TestObjects.ID == this.ID).FirstOrDefault();
                }
                return _Parent;
            }
        }
        public TestObjectCollection()
        {
            this.ID = Guid.NewGuid();
        }
        public void Add(TestObject newObject)
        {
            if (newObject != null)
                _testObjects.Add(newObject);
        }
        public IEnumerator<TestObject> GetEnumerator()
        {
            return _testObjects.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _testObjects.GetEnumerator();
        }
    }

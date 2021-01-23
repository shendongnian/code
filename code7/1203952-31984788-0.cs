    public class MyClass
    {
        [XmlIgnore]
        public List<int> ListTest { get; set; }
        [XmlElement("ListTest")]
        public int[] _listTest
        {
            get { return ListTest?.ToArray(); }
            set { ListTest = value == null ? null : new List<int>(value); }
        }
        ...
    }

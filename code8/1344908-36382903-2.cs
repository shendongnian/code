    [XmlInclude(typeof(string))]
    [XmlInclude(typeof(string[]))]
    [XmlInclude(typeof(object[]))]
    [XmlInclude(typeof(ListWrapper<string>))]
    [XmlInclude(typeof(ListWrapper<object>))]
    [XmlInclude(typeof(SortedSetWrapper<string>))]
    [XmlInclude(typeof(SortedSetWrapper<object>))]
    [XmlInclude(typeof(HashSetWrapper<string>))]
    [XmlInclude(typeof(HashSetWrapper<object>))]
    [XmlInclude(typeof(CollectionWrapper<LinkedList<string>, string>))]
    [XmlInclude(typeof(CollectionWrapper<LinkedList<object>, object>))]
    [XmlRoot(ElementName = "mc")]
    public class MyClass
    {
        [XmlElement("fm")]
        [JsonIgnore]
        public object XmlFirstMember
        {
            get
            {
                return CollectionWrapper.Wrap(FirstMember);
            }
            set
            {
                FirstMember = CollectionWrapper.Unwrap(value);
            }
        }
        [XmlIgnore]
        public object FirstMember;
    }

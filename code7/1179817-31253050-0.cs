    public class Foo
    {
        [XmlIgnore]
        public MyEnum myEnum { get; set; }
        [XmlElement("Bar")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _myEnum
        {
            get { return myEnum.ToString(); }
            set { myEnum = (MyEnum)Enum.Parse(typeof(MyEnum), value.Trim()); }
        }
    }

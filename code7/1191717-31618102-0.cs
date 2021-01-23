    [XmlInclude(typeof(Derived))]
    [Serializable]
    public class Base
    {
        public string str1;
        public string str2;
        public string str3;
    }
    [Serializable]
    public class  Derived : Base
    {
        public string str4;
        public string str5;
    }
    ....
    var ser = new XmlSerializer(typeof(Base));

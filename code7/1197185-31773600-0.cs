    public class CastleConfigSub
    {
        public ConfigFile ConfigFile { get; set; }
        [XmlAttribute()]
        public byte Format { get; set; }
    }
    public class ConfigFile
    {
        public List<Interface> Interfaces { get; set; }
        [XmlAttribute()]
        public string Name { get; set; }
    }
    public class Interface
    {
        public object Doc { get; set; }
        public List<Function> Functions { get; set; }
        [XmlAttribute()]
        public string Name { get; set; }
    }
    public class Function
    {
        public string Doc { get; set; }
        [XmlArrayItem("Arg")]
        public List<Arg> Args { get; set; }
        [XmlAttribute()]
        public string Name { get; set; }
    }
    [XmlInclude(typeof(ArgEnum))]
    [XmlInclude(typeof(ArgValue))]
    public class Arg
    {
        [XmlAttribute()]
        public string Name { get; set; }
    }
    public class ArgEnum : Arg
    {
        [XmlAttribute()]
        public string Enum { get; set; }
    }
    public class ArgValue : Arg
    {
        [XmlAttribute()]
        public string EncodedType { get; set; }
        [XmlAttribute()]
        public string Unit { get; set; }
    }

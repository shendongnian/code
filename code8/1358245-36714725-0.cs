    [Serializable]
    public abstract class ParameterBase : IParameter
    {
        [XmlAttribute("Name")]
        public abstract string Name { get; set; }
        [XmlIgnore]
        public abstract object UntypedValue { get; set; }
    }

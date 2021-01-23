    [Serializable]
    [XmlRoot("Parameter")]
    public class Parameter<T, V> : ParameterBase where V : IValidationPolicy<T>
    {
        [XmlAttribute("Name")]
        public override string Name { get; set; }
        ...
    }

        public class Parameter
        {
            [XmlText]
            public string Value { get; set; }
        }
        [XmlType("Root")]
        public class RootObject
        {
            [XmlElement("Parameter1", typeof(Parameter))]
            [XmlElement("Parameter2", typeof(Parameter))]
            [XmlChoiceIdentifier("ParametersElementName")]
            public Parameter[] Parameters { get; set; }
            [XmlIgnore]
            public ItemsChoiceType[] ParametersElementName { get; set; }
        }
        [XmlType(IncludeInSchema = false)]
        public enum ItemsChoiceType
        {
            Parameter1,
            Parameter2,
        }
    After deserialization, the `ParametersElementName` array will have the same number of entries as the `Parameters` array, and the `enum` values therein will indicate the XML element name actually encountered for each parameter.

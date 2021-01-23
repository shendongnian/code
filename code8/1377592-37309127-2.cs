        [XmlType("Root")]
        public class RootObject
        {
            [XmlElement("Parameter1", typeof(Parameter))]
            [XmlElement("Parameter2", typeof(Parameter))]
            [XmlChoiceIdentifier("ParametersElementName")]
            public Parameter[] Parameters { get; set; }
            [XmlIgnore]
            public ItemsChoiceType[] ParametersElementName
            {
                get
                {
                    if (Parameters == null)
                        return null;
                    return Parameters.Select(p => ItemsChoiceType.Parameter1).ToArray(); // Arbitrarily return ItemsChoiceType.Parameter1
                }
                set
                {
                    // Do nothing - don't care.
                }
            }
        }

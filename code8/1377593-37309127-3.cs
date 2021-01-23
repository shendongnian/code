    I.e. you could do:<p>
        public abstract class Parameter
        {
            [XmlText]
            public string Value { get; set; } // Could be int if you prefer.
        }
        public class Parameter1 : Parameter
        {
        }
        public class Parameter2 : Parameter
        {
        }
        [XmlType("Root")]
        public class RootObject
        {
            [XmlElement("Parameter1", typeof(Parameter1))]
            [XmlElement("Parameter2", typeof(Parameter2))]
            public Parameter[] Parameters { get; set; }
        }

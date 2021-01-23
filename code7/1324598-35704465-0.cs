        [XmlRoot("ClassName")]
        [DataContract]
        public class ClassName : IClassName
        {
            [DataMember]
            [XmlElement("Child1")]
            public string Child1 { get; set; }
            [DataMember]
            [XmlIgnore]
            public string Child2 { get; set; }
            [XmlElement("Child2")]
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
            [IgnoreDataMember]
            public CustomXmlNilTextWrapper Child2Xml { get { return Child2; } set { Child2 = value; } }
        }
        public struct CustomXmlNilTextWrapper
        {
            bool forceNull;
            string value;
            public static implicit operator CustomXmlNilTextWrapper(string value)
            {
                return new CustomXmlNilTextWrapper(value);
            }
            public static implicit operator string(CustomXmlNilTextWrapper wrapper)
            {
                return wrapper.Value;
            }
            public CustomXmlNilTextWrapper(string value)
            {
                this.value = value;
                this.forceNull = value == null;
            }
            [XmlAttribute("nil")]
            public bool ForceNull { get { return forceNull; } set { forceNull = value; } }
            public bool ShouldSerializeForceNull() { return ForceNull == true; }
            [XmlText]
            public string Value { get { return ForceNull ? null : value ?? string.Empty; } set { this.value = value; } }
        }

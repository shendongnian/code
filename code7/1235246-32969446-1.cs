    public class testTag01
    {
        [XmlAttribute]
        public string NV { get; set; }
        [XmlAttribute("nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get { return SomeEnum == null ? "true" : null; } set { } }
        public bool ShouldSerializeNil() { return SomeEnum == null; }
        [XmlIgnore]
        public SomeEnum? SomeEnum { get; set; }
        [XmlText]
        public string SomeEnumText
        {
            get
            {
                if (SomeEnum == null)
                    return null;
                return SomeEnum.Value.ToString();
            }
            set
            {
                // See here if one needs to parse XmlEnumAttribute attributes
                // http://stackoverflow.com/questions/3047125/retrieve-enum-value-based-on-xmlenumattribute-name-value
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                    SomeEnum = null;
                else
                {
                    try
                    {
                        SomeEnum = (SomeEnum)Enum.Parse(typeof(SomeEnum), value, false);
                    }
                    catch (Exception)
                    {
                        SomeEnum = (SomeEnum)Enum.Parse(typeof(SomeEnum), value, true);
                    }
                }
            }
        }
    }

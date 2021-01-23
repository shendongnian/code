    public class PersonDetails
    {
        [XmlAttribute]
        public string Address { get; set; }
        [XmlAnyAttribute]
        public XmlAttribute[] XmlAttributes
        {
            get
            {
                return null;
            }
            set
            {
                if (value != null)
                {
                    foreach (var attr in value)
                        if (attr.Name == "Address_x0_")
                            Address = attr.Value;
                }
            }
        }
    }

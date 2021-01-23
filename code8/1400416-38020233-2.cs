    public partial class location
    {
        bool nil;
        [XmlAttribute("nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public bool Nil
        {
            get
            {
                return nil;
            }
            set
            {
                nil = value;
            }
        }
        public bool ShouldSerializeNil() { return nil == true; }
    }

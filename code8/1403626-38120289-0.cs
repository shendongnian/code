    public class SurgeryReader : XmlTextReader
    {
        public SurgeryReader(string url) : base(url) { }
        public override string LocalName
        {
            get
            {
                if (base.LocalName.StartsWith("surgery"))
                    return "surgery";
                return base.LocalName;
            }
        }
    }

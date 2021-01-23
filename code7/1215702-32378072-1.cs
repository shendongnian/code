    namespace Q32345998_XsdVersion.v10
    {
        public partial class SomeConfig
        {
            public bool ElementAlwaysValid { get; set; }
            public string SomeElement { get; set; }
        }
    }
    namespace Q32345998_XsdVersion.v11
    {
        public partial class SomeConfig
        {
            public bool ElementAlwaysValid { get; set; }
    
            [XmlElement(IsNullable = true)]
            public string SomeElement { get; set; }
    
            public static explicit operator v10.SomeConfig(v11.SomeConfig v11)
            {
                return new v10.SomeConfig() { ElementAlwaysValid = v11.ElementAlwaysValid, SomeElement = v11.SomeElement };
            }
        }
    }
    namespace Q32345998_XsdVersion.v12
    {
        public partial class SomeConfig
        {
            public bool ElementAlwaysValid { get; set; }
    
            public static explicit operator v11.SomeConfig (v12.SomeConfig v12)
            {
                return new v11.SomeConfig() { ElementAlwaysValid = v12.ElementAlwaysValid, SomeElement = null };
            }
            public static explicit operator v10.SomeConfig(v12.SomeConfig v12)
            {
                return new v10.SomeConfig() { ElementAlwaysValid = v12.ElementAlwaysValid, SomeElement = null };
            }
    
        }
    }

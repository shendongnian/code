    public class Foo
    {
        public string Name { get; set; }
        public Bar Bar { get; set; }
        [XmlAnyElementAttribute]
        public XmlElement[] BarElements
        {
            get { return null; }
            set
            {
                Bar = new Bar();
                var barType = Bar.GetType();
                foreach (var prop in value)
                    barType.GetProperty(prop.Name.Substring(4)).SetValue(Bar, prop.InnerText);
            }
        }
    }
    public class Bar
    {
        public string Data { get; set; }
        public string MoreData { get; set; }
    }

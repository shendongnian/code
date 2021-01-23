    public class Item
    {
        [XmlAttribute("type")]
        public string type;
        [XmlAttribute("key")]
        public string key;
        [XmlIgnore] // Do not output the list to XML directly
        public List<int> Values { get; set; }
        [XmlText]  // Instead, output the list as a comma-separated string in the XML element's text value.
        public string XmlValue
        {
            get
            {
                if (Values == null)
                    return null;
                return string.Join(",", Values.Select(i => XmlConvert.ToString(i)).ToArray());
            }
            set
            {
                if (value == null)
                    Values = null;
                else
                {
                    Values = value.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => XmlConvert.ToInt32(s)).ToList();
                }
            }
        }
    }

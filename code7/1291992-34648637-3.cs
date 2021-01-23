    public class GroupFile
    {
        [XmlElement("Group")]
        public Group[] Groups { get; set; }
    }
    public class Group
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("Member")]
        public Member[] Members { get; set; }
    }
    [Serializable]
    public class Member : IXmlSerializable
    {
        public static string DecimalToHexadecimalEncoding(string html)
        {
            var splitted = html.Split('#');
            var res = Int32.Parse(splitted[1].Replace(";", string.Empty));
            return "&#x" + res.ToString("x4") + ";";
        }
        [XmlAttribute("id")]
        public int Id { get; set; }       
    
        [XmlIgnore]
        public string Value { get; set; }
        [XmlText]
        public string HexValue
        {
            get
            {
                // convert to hex representation
                var res = HttpUtility.HtmlEncode(Value);
                res = DecimalToHexadecimalEncoding(res);
                return res;
            }
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            var attributeValue = reader.GetAttribute("id");
            if (attributeValue != null)
            {
                Id = Int32.Parse(attributeValue);
            }
            // Here the value is directly converted to string "°"
            Value = reader.ReadElementString();            
            reader.ReadEndElement();           
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("id", Id.ToString());
            writer.WriteRaw(HexValue);
        }
    }

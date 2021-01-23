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
    public class Member
    {
        public static string DecimalToHexadecimalEncoding(string html)
        {
            var splitted = html.Split('#');
            var res = Int32.Parse(splitted[1].Replace(";", string.Empty));
            return "&#x" + res.ToString("x4");
        }
        public static string HexadecimalToDecimalEncoding(string html)
        {
            var splitted = html.Split('x');
            var res = Int32.Parse(splitted[1].Replace(";", string.Empty), 
                System.Globalization.NumberStyles.HexNumber);
            return "&#" + res;
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
            set
            {
                // convert hex representation back to string
                var res = HexadecimalToDecimalEncoding(value);
                Value = HttpUtility.HtmlDecode(res);
            }
        }

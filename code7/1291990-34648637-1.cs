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
        public static string UnicodeToEntity(string html)
        {
            var splitted = html.Split('#');
            var res = Int32.Parse(splitted[1].Replace(";", string.Empty));
            return "&#x" + res.ToString("x4");
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
                res = UnicodeToEntity(res);
                return res;
            }
            set
            {
                // convert hex representation back to string
                Value = HttpUtility.HtmlDecode(value);
            }
        }
    }

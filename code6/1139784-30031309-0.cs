    [XmlRoot("Userinfo")]
    public class UserInfo
    {
        [XmlElement("UserName")]
        public string Username { get; set; }
        [XmlElement("Age")]
        public string Age { get; set; }
    }

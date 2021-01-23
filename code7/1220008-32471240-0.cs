    [XmlRoot("GetUserProfileResponse", Namespace = "http://schemas.abudhabi.ae/sso/2010/11")] // Serialized with root element name "GetUserProfileResponse" in namespace "http://schemas.abudhabi.ae/sso/2010/11".
    public class UserProfile
    {
        [XmlElement("firstNameAr")] // Serialized with element name "firstNameAr".
        public string FirstNameAR { get; set; }
        [XmlElement("firstNameEn")]
        public string FirstNameEN { get; set; }
        [XmlElement("middleNameAr")]
        public string MiddleNameAR { get; set; }
        [XmlElement("middleNameEn")]
        public string MiddleNameEN { get; set; }
        [XmlElement("thirdNameAr")]
        public string ThirdNameAR { get; set; }
        [XmlElement("thirdNameEn")]
        public string ThirdNameEN { get; set; }
        // Fix others similarly.
    }

    [XmlRoot(ElementName="ClubRegisterQuick")]
    public class Root
    {
        public List<Club> Clubs { get; set; }
    }
    
    [Serializable]
    public class Club
    {
        public string Email { get; set; }
        public string Clubname { get; set; }
        public string Clubphonenumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Currency { get; set; }
        public string Password { get; set; }
        public string Clubtype { get; set; }
    }

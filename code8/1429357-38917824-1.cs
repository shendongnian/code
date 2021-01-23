    public class UserData
    {
        public string userID { get; set; }
        public string emailAddress { get; set; }
        public string fullName { get; set; }
        public string accountType { get; set; }
        public string units { get; set; }
        public string unitsDistance { get; set; }
        public string newsletterSub { get; set; }
 
        public string location { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string photo { get; set; }
        public string createdDate { get; set; }
        public string verifyURL { get; set; }
        public string timezone { get; set; }
        public APIManifestDict apiManifest { get; set; }
        public Dictionary<string,string> Metadata { get; set; }
    }

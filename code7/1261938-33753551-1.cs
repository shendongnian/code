    public class Response
    {
        public Meta Meta { get; set; }
        public Dictionary<string, UserData> Result { get; set; }
    }
    public class Meta
    {
        public string Status { get; set; }
        public string Debug { get; set; }
    }
    public class UserData
    {
        public string DivisionID { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserAccountType { get; set; }
        public string UserEmail { get; set; }
        public string UserAccountStatus { get; set; }
    }

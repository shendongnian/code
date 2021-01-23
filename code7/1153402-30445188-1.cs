    public class RootObject
    {
        public string id { get; set; }
        public string username { get; set; }
        public string username_canonical { get; set; }
        public string email { get; set; }
        public string email_canonical { get; set; }
        public string enabled { get; set; }
        public string salt { get; set; }
        public string password { get; set; }
        public string last_login { get; set; }
        public string locked { get; set; }
        public string expired { get; set; }
        public object expires_at { get; set; }
        public object confirmation_token { get; set; }
        public object password_requested_at { get; set; }
        public string roles { get; set; }
        public string credentials_expired { get; set; }
        public object credentials_expire_at { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
        public string cp { get; set; }
        public string ville { get; set; }
        public string dateEmbauche { get; set; }
    }

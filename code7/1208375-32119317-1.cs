    public class ApplicationConfiguration : Entity
    {
        public Applications Application { get; set; }
        public string ApiKey { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string HttpScheme { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual AdminConfiguration AdminConfiguration { get; set; }
        [ForeignKey("AdminConfiguration")]
        public int AdminConfigurationId { get; set; }
    }

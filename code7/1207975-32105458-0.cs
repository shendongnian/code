    public class AdminConfiguration : Entity // Entity is an abstract class containing an ID
    {
        public AdminConfiguration()
        {
            this.ApplicationConfigurations = new HashSet<ApplicationConfiguration>();
            this.LinksConfigurations = new HashSet<LinksConfiguration>();
        }
        public bool Authentication { get; set; }
        public EmailConfiguration EmailConfiguration { get; set; }
        public bool WakeOnLan { get; set; }
        // Navigation properties
        public virtual ICollection<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public virtual ICollection<LinksConfiguration> LinksConfigurations { get; set; }
    }

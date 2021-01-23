    public interface IMailSettings
    {
        string MailAddress { get; }
        string DefaultMailSubject { get; }
    }
    public interface IFtpInformation
    {
        int FtpPort { get; }
    }
    public interface IFlowerServiceInformation
    {
        string FlowerShopAddress { get; }
    }
    public class ConfigValues :
        IMailSettings, IFtpInformation, IFlowerServiceInformation
    {
        public string MailAddress { get; set; }
        public string DefaultMailSubject { get; set; }
        public int FtpPort { get; set; }
        public string FlowerShopAddress { get; set; }
    }
    // Register as
    public static void RegisterConfig(this Container container)
    {
        var config = new ConfigValues
        {
            MailAddress = ConfigurationManager.AppSettings["MailAddress"],
            DefaultMailSubject = ConfigurationManager.AppSettings["DefaultMailSubject"],
            FtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["FtpPort"]),
            FlowerShopAddress = ConfigurationManager.AppSettings["FlowerShopAddress"],
        };
        var registration = Lifestyle.Singleton.CreateRegistration<ConfigValues>(() => 
                                    config, container);
        container.AddRegistration(typeof(IMailSettings),registration);
        container.AddRegistration(typeof(IFtpInformation),registration);
        container.AddRegistration(typeof(IFlowerServiceInformation),registration);
    }
 

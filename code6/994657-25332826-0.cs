    public interface IConfiguration
    {
        string GetConfigurationValue(string key);
    }
    
    public interface IEmailHelper
    {
        void SendEmail(string from, string to, string subject, string message);
    }

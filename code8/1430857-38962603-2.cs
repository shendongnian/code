    public interface IAppSettings
    {
        string this[string key] { get; }
    }
    public class AppSettings : IAppSettings
    {
        public string this[string key] => ConfigurationManager.AppSettings[key];
    }

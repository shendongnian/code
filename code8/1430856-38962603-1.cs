    public interface IAppSettings
    {
        string this[string key] { get; }
    }
    [Serializable]
    public class AppSettings : NameValueCollection, IAppSettings
    {
        public new string this[string key] => ConfigurationManager.AppSettings[key];
    }

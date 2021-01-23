    public class DefaultAppSettings : IAppSettings
    {
        public T Get<T>(string name)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[name], typeof(T));
        }
    }

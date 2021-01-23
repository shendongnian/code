    using System.Configuration;
    public interface IApplicationSettings {
        string this[string setting] { get; }
    }
    public class ConfigAppSettings : IApplicationSettings {
        public string this[string setting] {
            get { return ConfigurationManager.AppSettings[setting]; }
        }
    }
    public interface IConnectionStrings {
        string this[string name] { get; }
    }
    public class ConfigConnectionStrings : IConnectionStrings {
        public string this[string name] {
            get { return ConfigurationManager.ConnectionStrings[name].ConnectionString; }
        }
    }

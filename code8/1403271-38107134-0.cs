    public interface IMySettings
    {
        string Setting1 {get;}
        string Setting2 {get;}
    }
    public class MyConfigurationSettings : IMySettings
    {
        public string Setting1
        {
            get { return ConfigurationManager.AppSettings["SomeKey"].ToString(); }
        }
        public string Setting2
        {
            get { return ConfigurationManager.AppSettings["SomeOtherKey"].ToString(); }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConfigFileAttribute : Attribute
    {
        ...
    }
    [ConfigFile("login.xml")]
    public class LoginConfiguration 
    {
        ...
    }

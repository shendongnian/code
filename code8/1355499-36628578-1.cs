    public class EnvironmentHelper
    {
        Func<string[]> getEnvironmentCommandLineArgs; 
           // other dependency injections can be placed here
           public EnvironmentHelper(Func<string[]> getEnvironmentCommandLineArgs)
           {
                this.getEnvironmentCommandLineArgs = getEnvironmentCommandLineArgs;
           }
           public string[] GetEnvironmentCommandLineArgs()
           {
                return getEnvironmentCommandLineArgs();
           }
    }

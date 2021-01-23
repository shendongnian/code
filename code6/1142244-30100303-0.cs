    using System.Configuration; 
    public class Configuration 
    { 
        public static IDocCartConfiguration GetConfiguration() 
        { 
            try
            {
                return IDocCartConfiguration)ConfigurationManager.GetSection("docCart");     
            }
            catch(ConfigurationErrorsException e)
            {
                 /* do something with the exception */
            }
        } 
    }

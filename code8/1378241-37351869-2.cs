    public class Helpers {
    
        public static IServerVariable ServerVariable {get;set;}
    
        public static bool TestMode()
        {
            if (ServerVariable != null 
                && (ServerVariable.Name == "localhost" || ServerVariable.Name == "test.org")
                )
                return true;
            else
                return false;
        }
    
    }

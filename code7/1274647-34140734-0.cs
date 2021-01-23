    public class  Authentication
    {
        public static string AuthenticationApplicationDirectory;
        public static string AuthenticationFileName = "Authentication.txt";
    
        static Authentication()
        {
            AuthenticationApplicationDirectory = Path.GetDirectoryName(Application.LocalUserAppDataPath) + "Authentication";
            if (!Directory.Exists(AuthenticationApplicationDirectory))
            {
                Directory.CreateDirectory(AuthenticationApplicationDirectory);
            }
            AuthenticationFileName = Path.Combine(AuthenticationApplicationDirectory, AuthenticationFileName);
        }
    }

        internal class Program
    {
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true)]
        public static extern bool DeleteProfile(string sidString, string profilePath, string omputerName);
        private static void Main(string[] args)
        {
            try
            {
                var username = args[0];
                var principalContext = new PrincipalContext(ContextType.Domain); // Domain => to support local user this should be changed probably, didn't test yet
                var userPrincipal = UserPrincipal.FindByIdentity(principalContext, username);
                if (userPrincipal != null)
                {
                    Console.WriteLine("User found");
                    var userSid = userPrincipal.Sid;
                    Console.WriteLine("User {0} has SID: {1}", username, userSid);
                    Console.WriteLine("Will try to DeleteProfile next..");
                    DeleteProfile(userSid.ToString(), null, null);
                    Console.WriteLine("Done - bye!");
                }
                else
                {
                    Console.WriteLine("ERROR! User: {0} not found!", username);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);   
            }
        }
    }

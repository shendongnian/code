    using System;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter First Name, then press enter.");
                var userName = Console.ReadLine();
    
                // Will search the domain the application is running on
                var principalContext = new PrincipalContext(ContextType.Domain);
                var user = UserPrincipal.FindByIdentity(principalContext, userName);
    
                if (user == null)
                {
                    Console.WriteLine("User Not Found");
                }
                else
                {
                    // Gets a list of the user's groups
                    var groups = user.GetGroups().ToList();
                    // Loops the groups and prints the SamAccountName
                    groups.ForEach(g => Console.WriteLine(g.SamAccountName));
                }
    
                Console.ReadKey();
            }
        }
    }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags = System.Security.Permissions.SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {
            try
            {
                new test(args[0], args[1]);
            }
            catch(Exception e)
            {
                Console.WriteLine(e)
            }
        }

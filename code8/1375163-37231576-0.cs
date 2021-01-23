    public class Library
    {
        public class ConnectionController
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ProjectName { get; set; }
            public string Domain { get; set; }
            public string SQLServer { get; set; }
            public string SQLDatabase { get; set; }
    
            public static ConnectionController Request(string Domain)
            {
                return InternalLibrary.ccList.
                    Where(m => m.Domain.Equals(Domain, 
                               StringComparison.CurrentCultureIgnoreCase)).
                    FirstOrDefault();
            }
        }
    
        private class InternalLibrary
        {
            public static readonly List<ConnectionController> ccList =
                new List<ConnectionController>
                { 
                    new ConnectionController()
                    { 
                        UserName = "x", 
                        Password="y",
                        ProjectName="r",
                        Domain = "z", 
                        SQLDatabase = "a", 
                        SQLServer = "b"
                    }
                };
        }
    }

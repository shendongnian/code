    namespace Library
    {
    public class ConnectionController
    {
        private static readonly List<ConnectionController> CcList = new List<ConnectionController>
        {
            new ConnectionController
            {
                UserName = "x",
                Password = "y",
                ProjectName = "r",
                Domain = "z",
                SQLDatabase = "a",
                SQLServer = "b"
            }
        };
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProjectName { get; set; }
        public string Domain { get; set; }
        public string SQLServer { get; set; }
        public string SQLDatabase { get; set; }
        public static ConnectionController Request(string domain)
        {
            return CcList.Where(m => m.Domain.ToUpper() == domain.ToUpper())
                .Select(m => new ConnectionController
                {
                    UserName = m.UserName,
                    Password = m.Password,
                    ProjectName = m.ProjectName,
                    Domain = m.Domain,
                    SQLServer = m.SQLServer,
                    SQLDatabase = m.SQLDatabase
                }).ToList()[0];
        }
    }
    }

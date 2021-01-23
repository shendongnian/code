    public class MyOdataController : ODataController
    {
        protected AMMetricsEntities db;
        protected EntityConnection ec;
        protected IEnumerable<Claim> claims;
        protected long userId;
        protected string userName;
        private string GetConnectionString(string dbId, string dbName)
        {
            // this is where we get token from header information and populate the connection string
            return
                String.Format(
                    "metadata=res://*/Models.AMModel.csdl|res://*/Models.AMModel.ssdl|res://*/Models.AMModel.msl;" +
                    "provider=System.Data.SqlClient;" +
                    "provider connection string='data source={0};initial catalog={1};persist security info=True;user id={2};password={3};" +
                    "multipleactiveresultsets=True;application name=EntityFramework'",
                    dbServer,
                    dbName,
                    Username,
                    Password);
        }
        public MyOdataController()
        {
            claims = ((ClaimsIdentity)User.Identity).Claims;
            if (claims.Any())
            {
                userId = Convert.ToInt64(User.Identity.GetUserId());
                userName = User.Identity.GetUserName();
                var dbName = claims.Where(s => s.Type == "DBName").Select(c => c.Value).First();
                var dbServer = claims.Where(s => s.Type == "DBServer").Select(c => c.Value).First();
                ec = new EntityConnection(GetConnectionString(dbServer, dbName));
                db = new ProductEntities(ec, false);
            }
        }
    }

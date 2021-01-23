    using System.Net;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");
    
        using (var db = new MyDbContext("...")) {
            log.Info(db.Events.First().id.ToString());
        }
    }
    
    #region POCOs
    public class Event {
        public long id {get;set;}
        public string data {get;set;}
    }
    #endregion
    public partial class MyDbContext : System.Data.Entity.DbContext {
        public MyDbContext(string cs) : base(cs) { }
        public DbSet<Event> Events {get;set;}
    }

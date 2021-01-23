    [RoutePrefix("api/foo")]
    public class FooController : _SignalRBase<FooHub>
    {
        public IHttpActionResult Bar(FooDTO foo)
        {
            // notify all connected clients
            GolbalHost.ConnectionManager.GetHubContext<FooHub>().Clients.All.newFoo(foo);
    
            return Ok(foo);
        }
    }

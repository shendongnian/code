    [RoutePrefix("api/foo")]
    public class FooController : ApiController
    {
        public IHttpActionResult Bar(FooDTO foo)
        {
            // notify all connected clients
            GolbalHost.ConnectionManager.GetHubContext<FooHub>().Clients.All.newFoo(foo);
    
            return Ok(foo);
        }
    }

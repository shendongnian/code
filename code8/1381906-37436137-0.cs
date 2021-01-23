    [RoutePrefix("item")]
    public class ItemController : ApiController
    {
        [HttpGet]
        [Route("dosomething")]
        public void DoSomething(Item item)
        { }
    
        [HttpGet]
        [Route("dosomethingnicer")]
        public void DoSomethingNicer(Item item)
        { }
    
        [HttpGet]
        [Route("dosomethingelse")]
        public void DoSomethingElse(Item item)
        { }
    }

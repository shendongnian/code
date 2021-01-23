    public class FooController : ApiController
    {
        ITaskRunner runner;
        
        public FooController(ITaskRunner runner) { this.runner = runner; }
    
       Public IActionResult DoStuff() {
           runner.AddTask(() => { Stuff(); });
           return Ok();
       }
    }

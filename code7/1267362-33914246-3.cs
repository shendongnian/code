    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class HomeController : Controller
    {
    
            
        public async Task<string> SlowProcess()
        {
    
            Session["Hello"] = "World";
    
            await Task.Delay(5000);
            return "Hello, world!";
        }
    
    
    }

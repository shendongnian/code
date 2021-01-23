    public class SomeAreaController : BaseController {
        
        public ActionResult Test() {
            
            ViewModel vm = new ViewModel();
            this.PopulateViewModel( vm );
            
            // and if you still need access to a DbContext, use the inherited property:
            this.DBContext.DoSomething();
            
            return this.View( vm );
        }
    }

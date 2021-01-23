    public class MyController : Controller{
    
       //this will be resolved in runtime(either CommuniucationService or FakeCommunicationService )
       private readonly ICommuniucationService EmailSvc;
    
       // Use constructor injection for the dependencies
       public MyController(ICommuniucationService svc) {
           this.EmailSvc= svc;       
       }
       public ActionResult Create(string name){
    
            // create and save to database
    
            // if success 
            // select admin emails from database.
            // create email content and subject.
            
            this.EmailSvc.SendEmail(...)
   
            //The action code doesn't change neither for 
       }
    }

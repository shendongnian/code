    public class SomeService: BaseService, ISomeService
    {
        public MyService(IUnitOfWork scope) : base(scope)
        {
    
        }
      public void SomeMethod(int somevalue)
      {
        
        //Do something in this service
        //code here.....
    
       //then do something in the next service, passing though 
        //the same unitof work
    
        messageService = new MessageService(_uow );
        messageService.Send(1, 2, "some text");
      }
    }

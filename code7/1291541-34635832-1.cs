    public class Consumer
    {
      private IUserRepo repo;  
    
      public Consumer(IUserRepo repo)
      {
        this.repo = repo;
      }
    
      public void DoStuff()
      { 
        // Act upon repository
      }
    }

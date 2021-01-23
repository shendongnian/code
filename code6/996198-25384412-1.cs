    public class Example { 
      private IDatabaseGateway myDatabase; 
    
      public Example(IDatabaseGateway myDb) { 
        myDatabase = myDb;
      } 
    
      public void DoStuff() { 
        ... 
        myDatabase.GetData(); 
        ... 
      } 
    }

    public class Session
    {
      public int SessionId{get;set;}
      public List<string> SessionLog{get;set;}
    }
    
    List<Session> objList = new List<Session>();
    
    var session1 = new Session();
    session1.SessionId = 1;
    session1.SessionLog.Add("description lline1");
    
    objList.Add(session1);

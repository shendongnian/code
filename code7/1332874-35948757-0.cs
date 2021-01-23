    public class MyContent{
       public string RCV{get;set;}
       public string SND{get;set;}
       public string TXT{get;set;}
    }
    
    public ActionResult Receiver([FromBody] MyContent contentBody)

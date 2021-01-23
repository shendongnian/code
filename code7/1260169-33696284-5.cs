    public class Server
    {
       [WebMethod]
       [ScriptMethod(UseHttpGet = true)]
       public string GetMyName()
       {
           return "MyName";
       }
    }

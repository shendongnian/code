    public class Server
    {
       [WebMethod]
       [ScriptMethod(UseHttpGet = true)]
       public static string GetMyName()
       {
           return "MyName";
       }
    }

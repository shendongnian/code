    public class MyPage : System.Web.UI.Page
    {
         protected override void OnError(EventArgs e)
         {
             Exception TheException = Server.GetLastError();
             // todo: log the exception to the database
             base.OnError(e); //pass the exception to the regular handler
             return;
         }
    }

    public class Helpers
    {
        public static void DisplayErrorMessage(Page page, string msg)
        {
            string script = "<script language='javascript'>alert('" + msg + "');</" + "script>";
            if (!page.ClientScript.IsStartupScriptRegistered("MyAlertMsgHandler"))
                page.ClientScript.RegisterStartupScript(page.GetType(), "MyAlertMsgHandler", script);
        }
    }

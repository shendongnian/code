    public class Helpers
    {
        public static void DisplayErrorMessage(Page page, string msg)
        {
            string script = "<script>alert('" + msg + "');</script>";
            if (!page.ClientScript.IsStartupScriptRegistered("MyAlertMsgHandler"))
                page.ClientScript.RegisterStartupScript(page.GetType(), "MyAlertMsgHandler", script);
        }
    }

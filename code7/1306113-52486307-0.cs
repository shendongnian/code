    public static void ConsoleLog(this Page page, string msg)
    {
        msg = msg.Replace("'", ""); //Prevent js parsing errors. Could also add in an escape character instead if you really want the 's.
        page.Response.Write("<script>console.log('"+msg+"');</script>");
    }

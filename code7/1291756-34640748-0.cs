    public static void ShowClientMessageDlg(string msg, string aValue, string redirect = "")
    {
        string msgFormat;
        msgFormat = string.Format(" {0}", aValue);
        msg = msg + msgFormat;
        HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + msg + "');</script>");
    }

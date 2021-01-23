     protected void Page_Load(object sender, EventArgs e)
    {
        Exception err = Session["LastError"] as Exception;
        //Exception err = Server.GetLastError();
        if (err != null)
        {
            err = err.GetBaseException();
            lblErrorMsg.Text = err.Message;
            lblSource.Text = err.Source;
            lblInnerEx.Text = (err.InnerException != null) ? err.InnerException.ToString() : "";
            lblStackTrace.Text = err.StackTrace;
            Session["LastError"] = null;
        }
    }
 

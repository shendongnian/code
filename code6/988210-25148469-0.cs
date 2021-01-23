    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
        //ICallBack event handler
        ClientScriptManager cm = Page.ClientScript;
        string cbReference = cm.GetCallbackEventReference(this, "arg", "HandleResult", "");
        string cbScript = "function RaiseEvent(arg){" + cbReference + ";}";
        cm.RegisterClientScriptBlock(this.GetType(), "RaiseEvent", cbScript, true);
        //End of ICallBack event handler
        }
    }

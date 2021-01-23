    protected void Page_LoadComplete(object sender, EventArgs e)
    {
       qData["businessName"] = Request.QueryString["businessName"]);
    }
    protected void craCHeck(object sender, EventArgs e)
    {
       string value = "";
       qData.TryGetValue("businessName", out value))
    }

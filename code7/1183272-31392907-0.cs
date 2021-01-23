    //set the value on some action...
    Session["provSel"] = {value};
    ...
    if (IsPostBack)
    {
        if (Session["provSel"] != null)
    	{
    		string role = Session["provSel"].ToString();
    	}
    }

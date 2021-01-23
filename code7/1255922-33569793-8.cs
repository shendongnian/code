            protected void Page_Load(object sender, EventArgs e)
            {
                 //Only if the event argument was from my drop down add the event
                    if (Request.Params["__EVENTARGUMENT"] != null && Request.Params["__EVENTARGUMENT"].Equals("ddlSplitTypechange"))
                        ddlSplitType_SelectedIndexChanged(sender, e);
                    if (!Page.IsPostBack)
                    {
                        ddlSplitType.Attributes.Add("onchange", "confirm_change();");
                }
            }
            protected void ddlSplitType_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }

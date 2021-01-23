    protected void EndSession(object sender, EventArgs e)
    {
        string value = Request.Form[txtconfirmmessageValue.UniqueId];
    
        if (!Utility.ToBool(value))
        {
            return;
        }
    }

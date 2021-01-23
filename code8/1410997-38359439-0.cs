    protected override void OnPreRender(EventArgs e)
    {
        if (Page.IsPostBack && !IsPostBackEventControlRegistered)
        {
            var controlName = this.Request.Form.AllKeys.SingleOrDefault(key => key.Contains("DYNAMIC_"));
            processEventForDynamicControl(controlName);
        }
        base.OnPreRender(e);
    }
    private void processEventForDynamicControl(string controlName)
    {
        //Do your dynamic button click processing here
    }

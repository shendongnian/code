    protected override void InitializeCulture()
    {
        //read posted value
        if (IsPostBack)
        {
            Session["Lang"] = Request.Form[LangRadioButton.UniqueID];
        }
        //set default value if it's empty
        if (String.IsNullOrEmpty(Session["Lang"]))
        {
            Session["Lang"] = "en-US";
        }
        
        string cultureName = Session["Lang"].ToString();
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        base.InitializeCulture();
    }

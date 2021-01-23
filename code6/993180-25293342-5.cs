    private bool IsValidUrl
    {
        get
        {
            if (Session["IsValidUrl"] != null)
                return Convert.ToBoolean(Session["IsValidUrl"]);
            return false;
        }
        set { Session["IsValidUrl"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsValidUrl)
        {
            // user comes from valid url. 
            // .... Do somthing
            
            // Reset session state value
            IsValidUrl = false;
        }
    }

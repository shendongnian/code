    public bool FirstValue
    {
        get
        {
            object o = ViewState["FirstValue"];
            if (o == null) return false; // default is false
            return (bool) o;
        }
        set
        {
            ViewState["FirstValue"] = value;
        }
    }
    ...
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        if (!Page.IsPostBack)
        {
            FirstValue = true;
        }
    }
    

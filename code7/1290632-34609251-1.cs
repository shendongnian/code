    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // presuming the type of your control is MyUserControl
            var allUCs = this.GetControlsRecursively().OfType<MyUserControl>();
            foreach (MyUserControl uc in allUCs)
            {
                // do something with it
            }
        }
    }

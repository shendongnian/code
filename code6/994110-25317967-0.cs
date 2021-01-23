    protected AVModel Model
    {
        get
        {
            if(this.Page is AVMain)
            { 
                var page = this.Page as AVMain;
                return page.Model;
            }
            return null;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.IsAudit.HasValue && SessionData.IsAudit.Value == true)
        {
            cbFlagAudit.Visible = false;
        }
        if (!IsPostBack)
        {
            var model = this.Model;
            Boolean? value = null;
            if(model != null)
            {
                value = model.FlagForAudit;
            }
            cbFlagAudit.Checked = (value.HasValue && value.Value)
        }
    }

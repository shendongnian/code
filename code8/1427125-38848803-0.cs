    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptSample.DataSource = getData();
            rptSample.DataBind();
        }
    }
    private List<string> getData()
    {
        return new List<string> { "1", "2", "3" };
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptSample.Items)
        {
            CheckBox chkbx = (CheckBox)item.FindControl("chkbxDelete");
            if (chkbx.Checked)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }

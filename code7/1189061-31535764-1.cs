    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAction.Enabled = false;
        }
    }
    
     
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ValidateCheckbox(); 
    }
    
    protected void ValidateCheckbox()
    {
        bool IsEnabled = false;
    
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            CheckBox CheckBox1 = item["CheckBoxTemplateColumn"].FindControl("CheckBox1") as CheckBox;
            if (CheckBox1.Checked)
            {
                IsEnabled = true;
                break;
            }
        }
    
        ddlAction.Enabled = IsEnabled;
    }

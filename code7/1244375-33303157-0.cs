    public OnLoad(...)
    {
        if(!Page.IsPostBack)
        {
            BuidNavigationList();
        }
        LoadNavigation();
    }
    private List<string> NavigationList
    {
        get
        {
            if (ViewState["NavigationList"] != null)
            {
                return (List<string>)ViewState["NavigationList"];
            }
            return null;
         }
         set
         {
             ViewState["NavigationList"] = value;
         }
    }
    private void BuidNavigationList()
    {
        // ds get
        if (ds.Tables.Count == 1)
        {
            DataTable dataTable = ds.Tables[0];
            if (dataTable.Columns.Contains("YourSwitchColumn"))
            {
                NavigationList = new List<string>(dataTable.Rows.Cast<DataRow>().Select(r => r["YourSwitchColumn"]).Cast<String>());
            }
        }
    }
    private string YourCurrentSwitchColumnValue
    {
        get
        {
            return Request["YourSwitchColumn"].ToString();
        }
    }
    private void LoadNavigation()
    {
         if(this.NavigationList == null)
         {
             lblPrevious.Enabled = false;
             lblNext.Enabled = false;
         }
         int navigationListIndex = NavigationList.IndexOf(YourCurrentSwitchColumnValue);
         if (navigationListIndex == 0)
         {
             lblPrevious.Enabled = false;
             lblNext.Enabled = true;
             lblNext.Value = NavigationList[navigationListIndex + 1];
         }
         else if (navigationListIndex > 0 && navigationListIndex < NavigationList.Count - 1)
         {
             lblPrevious.Enabled = true;
             lblNext.Enabled = true;
             lblPrevious.Value = NavigationList[NavigationListIndex - 1];
             lblNext.Value = NavigationList[NavigationListIndex + 1];                
         }
         else if (navigationListIndex == NavigationList.Count - 1)
         {
             lblPrevious.Enabled = true;
             lblNext.Enabled = false;
             lblPrevious.Value = NavigationList[NavigationListIndex - 1];                
         }
     }
     public void lblNext_OnClick(object sender, ...)
     {
         Request.Redirect("SamePage.aspx?YourSwitchColumn=" + valueFrom_lblNext);
     }

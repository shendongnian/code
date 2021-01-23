    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!Page.IsPostBack)
    	{
    		List<lookupCVRT> work = lookupCVRT.GetCVRTItems(Company.Current.CompanyID, ParentID.ToString());
    		gvCVRT.DataSource = work;
    		gvCVRT.DataBind();
    	 }
    }
    
    protected void gridviewParent_SelectedIndexChanged(object sender, EventArgs e)
    {
    	List<lookupCVRT> workDetails = lookupCVRT.GetChecklistItemsByChecklistID(Company.Current.CompanyID, ParentID.ToString(), gvCVRT.SelectedDataKey.Value.ToString());
    	gvCVRTDetails.DataSource = workDetails;
    	gvCVRTDetails.DataBind();
    }

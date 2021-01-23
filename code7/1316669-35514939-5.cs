    // field moved to class level so that you can access this variable instead of a DataRow in gvCVRT
    private List<lookupCVRT> work;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetChecklistID = "";
            if (ParentID.HasValue)
            {
                ViewState["ParentID"] = ParentID;
                work = lookupCVRT.GetCVRTItems(Company.Current.CompanyID, ParentID.ToString());
                ViewState["CVRT"] = work;
                gvCVRT.DataSource = work;
                gvCVRT.DataBind();
            }
        }
        else
        {
            if (ViewState["ParentID"] != null)
            {
                ParentID = (int?)ViewState["ParentID"];
                work = ViewState["CVRT"] as List<lookupCVRT>;
            }
        }
    }

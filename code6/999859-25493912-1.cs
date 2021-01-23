    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int GroupID = BusinessLayer.Group_Table.GetByUniqName(Page.RouteData.Values["GroupName"].ToString());
            GObject = new BusinessLayer.Group_Table(GroupID);
            DataBindDataList(); // code that calls DataBind
        }
    }
    private BusinessLayer.Group_Table GObject;

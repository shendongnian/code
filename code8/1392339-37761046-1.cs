    private dynamic getregion()
    {
      using(TrackDataEntities1 tee=new TrackDataEntities1())
      {
        return (from ta in tee.tblReg select new { ID = ta.YourColumn,DisplayText = ta.Region+ta.StartDate.ToShortDateString()+ ta.EndDate.ToShortDateString() }).ToList();
    
      }
    
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!Page.IsPostBack)
      {
        regiondrop.DataSource = getregion();
        regiondrop.DataTextField = "data";
        regiondrop.DataValueField = "ID";
        regiondrop.DataBind();
    
      }
    }

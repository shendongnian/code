    private List<tblRegion_Uni> getregion()
        {
       using(TrackDataEntities1 tee=new TrackDataEntities1())
             {
                 return (from ta in tee.tblReg select new { ta.Region, ta.StartDate, ta.EndDate }).ToList();
    
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

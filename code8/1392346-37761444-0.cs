    private List<Object> getregion()
        {
       using(TrackDataEntities1 tee=new TrackDataEntities1())
             {
                 return (from ta in tee.tblReg select new { Id = ta.ID, Data = ta.Region+ " " +ta.StartDate.ToString("dd/MM/yyyy HH:mm:ss")+ " "+ta.EndDate.ToString("dd/MM/yyyy HH:mm:ss") }).ToList();
    
             }
    
        }
    
     protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                regiondrop.DataSource = getregion();
                regiondrop.DataTextField = "Data";
                regiondrop.DataValueField = "Id";
                regiondrop.DataBind();
    
            }
        }

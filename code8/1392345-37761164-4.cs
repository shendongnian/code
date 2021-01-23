    private List<MyList> getregion()
        {
           using(TrackDataEntities1 tee=new TrackDataEntities1())
             {
                 var tempList=tee.tblReg.ToList();
                 var list=(from ta in tempList
                          let data = ta.Region + " " + ta.StartDate??DateTime.Now.ToString() + " " + ta.EndDate??DateTime.Now.ToString() 
                          select new{data, ta.ID}).Select(x=> new MyList{
                          Id=x.ID,
                          Data=x.data}).ToList();
                 return list;
             }
    
        }
    if(!Page.IsPostBack)
    {
             regiondrop.DataSource = getregion();
             regiondrop.DataTextField = "Data";
             regiondrop.DataValueField = "Id";
             regiondrop.DataBind();
    }

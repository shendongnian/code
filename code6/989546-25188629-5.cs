    public FirstPageClass ftPage;    
    DataTable dtNewTable;
    
    protected void Page_Load(object sender, EventArgs e)
    { 
         if (!Page.IsPostBack)
               ftPage= (FirstPageClass)Context.Handler;
    
         dtNewTable = (DataTable)ftPage.DataTransferTable;
    
         lstSecondView.DataSource = dtNewTable;
         lstSecondView.DataBind();              
    }

    public PagingSample.UpdatePanel upPanel;    
    DataTable dtNewTable;
    
    protected void Page_Load(object sender, EventArgs e)
    { 
         if (!Page.IsPostBack)
               upPanel = (PagingSample.UpdatePanel)Context.Handler;
    
         dtNewTable = (DataTable)upPanel.DataTransferTable;
    
         lstSecondView.DataSource = dtNewTable;
         lstSecondView.DataBind();              
    }

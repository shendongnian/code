    public abstract class BasePage: ParentPage
    {
        protected abstract GridView GetGridView();
        
        protected abstract DataTable GetAllData();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecords();
        }
    
        public virtual void DisplayRecords()
        {
            var gridView = this.GetGridView();
            gridView.DataSource = this.GetAllData();
            gridView.DataBind();
        }
    
        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            DisplayRecords();
        }
    
        protected void GridView1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            var index = e.NewPageIndex;
            DisplayRecords();
        }
    
        protected void GridView1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            var size = e.NewPageSize;
            DisplayRecords();
        }
    }

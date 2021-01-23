    public abstract class BasePage<T>: ParentPage
    {
        protected int pageIndex = 0;
        protected int pageSize = Settings.DefaultPageSize; //some constant value
        protected string sortExpression = string.Empty; 
        protected GridSortOrder sortOrder = GridSortOrder.None;
        protected abstract GridView GetGridView();
        
        protected abstract IQueriable<T> GetAllData();
        public virtual void DisplayRecords()
        {
            var gridView = this.GetGridView();
            gridView.DataSource = this.GetAllData();
            gridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecords();
        }
    
        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            this.sortOrder = e.NewSortOrder;
            this.sortExpression = e.SortExpression;
            DisplayRecords();
        }
    
        protected void GridView1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.pageIndex = e.NewPageIndex;
            DisplayRecords();
        }
    
        protected void GridView1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.pageSize = e.NewPageSize;
            DisplayRecords();
        }
    }

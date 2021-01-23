    public class ParentPage
    {
        public virtual void DisplayRecords()
        {
            var gridView = this.GetGridView();
            gridView.DataSource = this.GetAllData();
            gridView.DataBind();
        }
        protected virtual  DataTable GetAllData()
        {
            using (var context = new MyDataContext())
            {
                var data = context.Set<T>();
                return MyDataContext.LINQToDataTable(data);
            }
        }
        protected string GetSortOrder()
        {
            if (this.sortOrder != GridSortOrder.Assending)
                return string.Format("{0} DESC", this.sortExpression)
            return this.sortExpression;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecords();
        }
    
        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
            }
        }
    
        protected void GridView1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            e.Item.OwnerTableView.PageIndex = e.NewPageIndex;
            DisplayRecords();
        }
    
        protected void GridView1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            e.Item.OwnerTableView.PageSize = e.NewPageSize;
            DisplayRecords();
        }
    }
    Page 1:**ttt.aspx**
    public class **tttPage : BasePage<tttEntity> 
    {
        protected override GridView GetGridView()
        {
            //return GridView of this page 
            return GridView1;
        }
    }
    Page 1:**bbb.aspx**
    public class **bbbPage : BasePage<bbbEntity> 
    {
        protected override GridView GetGridView()
        {
            //return GridView of this page 
            return GridView1;
        }
    }

    public abstract class ParentPage<TEntity>
    {
        public virtual void DisplayRecords(GridView gridView)
        {
            gridView.DataSource = this.GetAllData();
            gridView.DataBind();
        }
        protected abstract  DataTable GetAllData();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    
        protected void GridView_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    
        protected void GridView_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    
        protected void GridView_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    }
    public class **tttPage : ParentPage 
    {
        protected override  DataTable GetAllData()
        {
            using (var context = new MyDataContext())
            {
                var data = c in context.ttt select c;
                return MyDataContext.LINQToDataTable(data);
            }
        }
    }
    public class **bbbPage : ParentPage 
    {
        protected override  DataTable GetAllData()
        {
            using (var context = new MyDataContext())
            {
                var data = c in context.bbb select c;
                return MyDataContext.LINQToDataTable(data);
            }
        }
    }

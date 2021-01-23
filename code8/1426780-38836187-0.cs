     public   class MyDataPagerGridView : GridView, IPageableItemContainer
        {
            private static readonly object EventTotalRowCountAvailable = new object();
    
            public int MaximumRows
            {
                get { return this.PageSize; }
            }
    
            public int StartRowIndex
            {
                get { return this.PageSize * this.PageIndex; }
            }
    
            public event EventHandler<PageEventArgs> TotalRowCountAvailable
            {
                add { base.Events.AddHandler(MyDataPagerGridView.EventTotalRowCountAvailable, value); }
                remove { base.Events.RemoveHandler(MyDataPagerGridView.EventTotalRowCountAvailable, value); }
            }
    
            public void SetPageProperties(int startRowIndex, int maximumRows, bool databind)
            {
                int newPageIndex = (startRowIndex / maximumRows);
                this.PageSize = maximumRows;
                if (this.PageIndex != newPageIndex)
                {
                    bool isCanceled = false;
                    if (databind)
                    {
                        //  create the event arguments and raise the event
                        GridViewPageEventArgs args = new GridViewPageEventArgs(newPageIndex);
                        this.OnPageIndexChanging(args);
                        isCanceled = args.Cancel;
                        newPageIndex = args.NewPageIndex;
                    }
                    //  if the event wasn't cancelled change the paging values
                    if (!isCanceled)
                    {
                        this.PageIndex = newPageIndex;
                        if (databind)
                            this.OnPageIndexChanged(EventArgs.Empty);
                    }
                    if (databind)
                        this.RequiresDataBinding = true;
                }
            }
    
            protected virtual void OnTotalRowCountAvailable(PageEventArgs e)
            {
                EventHandler<PageEventArgs> handler = (EventHandler<PageEventArgs>)base.Events[MyDataPagerGridView.EventTotalRowCountAvailable];
                if (handler != null)
                {
                    handler(this, e);
                }
            }
    
            protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
            {
                int rows = base.CreateChildControls(dataSource, dataBinding);
    
                //  if the paging feature is enabled, determine the total number of rows in the datasource
                if (this.AllowPaging)
                {
                    // if we are databinding, use the number of rows that were created, 
                    // otherwise cast the datasource to an Collection and use that as the count
                    int totalRowCount = dataBinding ? rows : ((ICollection)dataSource).Count;
    
                    //  raise the row count available event
                    IPageableItemContainer pageableItemContainer = this as IPageableItemContainer;
                    this.OnTotalRowCountAvailable(new PageEventArgs
                    (pageableItemContainer.StartRowIndex, pageableItemContainer.MaximumRows, totalRowCount));
    
                    //  make sure the top and bottom pager rows are not visible
                    if (this.TopPagerRow != null)
                        this.TopPagerRow.Visible = false;
    
                    if (this.BottomPagerRow != null)
                        this.BottomPagerRow.Visible = false;
                }
                return rows;
            }
    
            
        }
    
        public partial class DataPagerGridView : UserControl
        {
            public MyDataPagerGridView DataPagerGrid = new MyDataPagerGridView();
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
        }

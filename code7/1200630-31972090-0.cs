    protected void Page_Load(object source, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            RadGrid1.ShowFooter = true;
        }
    }
    
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dynamic data = new[] {
            new { ID = 1, Name ="Name1"},
            new { ID = 2, Name ="Name2"}
        };
        RadGrid1.DataSource = data;
    }
    
    protected void RadGrid1_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
    {
        if (e.Column.DataType.Name == "Int32")
        {
            GridBoundColumn bndcol = (GridBoundColumn)e.Column;
            bndcol.Aggregate = GridAggregateFunction.Sum; 
        }
    } 

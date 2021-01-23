c#
protected void Page_Init(object sender, System.EventArgs e)
{
	// create the Grid object
	RadGrid grid = new RadGrid();
    grid.ID = "RadGrid1";
    grid.DataSourceID = "SqlDataSource1";
    grid.AutoGenerateColumns = false;
    //Add Customers table  
    grid.MasterTableView.Width = Unit.Percentage(100);
    grid.MasterTableView.DataKeyNames = new string[] { "CustomerID" };
	
	// Attach event handlers on every postback
    RadGrid1.ItemDataBound += RadGrid1_ItemDataBound;
    
	// create the column object
	GridBoundColumn boundColumn = new GridBoundColumn();
	// column settings
    boundColumn.DataField = "CustomerID";
    boundColumn.HeaderText = "Customer ID";
	// add the column to the columns collection
    grid.MasterTableView.Columns.Add(boundColumn);
	
    // Add the grid to the placeholder  
    this.PlaceHolder1.Controls.Add(grid);
}
When using the Load event, only the Grid object, and its events need to be created at every page load. Every other configuration such as adding columns programmatically, must be created only at initial load as the ViewState will take care of them the next time the Grid is present on the page.
c#
protected void Page_Load(object sender, System.EventArgs e)
{
    RadGrid RadGrid1 = new RadGrid();
    RadGrid1.ID = "RadGrid1";
    // Attach event handlers on every postback
    RadGrid1.ItemDataBound += RadGrid1_ItemDataBound;
    // Add RadGrid to the Controls collection of the placeholder
    PlaceHolder1.Controls.Add(RadGrid1);
	// Configure the Grid settings, add columns, etc...
    if (!IsPostBack)
    {
        RadGrid1.DataSourceID = "SqlDataSource1";
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "CustomerID" };
        RadGrid1.AllowPaging = true;
        RadGrid1.MasterTableView.AutoGenerateColumns = false;
        RadGrid1.PageSize = 15;
        GridBoundColumn boundColumn;
        boundColumn = new GridBoundColumn();
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        boundColumn.DataField = "CustomerID";
        boundColumn.HeaderText = "CustomerID";
    }
}
  [1]: https://docs.telerik.com/devtools/aspnet-ajax/controls/grid/data-binding/understanding-data-binding/server-side-binding/advanced-data-binding-(using-needdatasource-event)
  [2]: https://www.telerik.com/support/kb/aspnet-ajax/grid/details/how-to-bind-radgrid-properly-on-server-side
  [3]: https://docs.telerik.com/devtools/aspnet-ajax/controls/grid/defining-structure/creating-a-radgrid-programmatically
  [4]: https://docs.telerik.com/devtools/aspnet-ajax/controls/grid/control-lifecycle/telerik-radgrid-lifecycle
  [5]: https://docs.telerik.com/devtools/aspnet-ajax/controls/grid/control-lifecycle/event-sequence

    private DataTable purchase_display_data
    {
        get
        {
            return (DataTable)ViewState["purchase_display_data"];
        }
        set
        {
            ViewState["purchase_display_data"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataColumn rownumber = new DataColumn();
            rownumber.DataType = System.Type.GetType("System.Int16");
            rownumber.AutoIncrement = true;
            rownumber.AutoIncrementSeed = 1;
            rownumber.AutoIncrementStep = 1;
            purchase_display_data.Columns.Add(rownumber);
            purchase_display_data.Columns.Add("Item");
            purchase_display_data.Columns.Add("Charge");
        }
     }

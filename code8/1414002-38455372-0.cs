    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
          BindRadComboBox();
       }
    }
    
    private void BindRadComboBox()
    {
        string f2 = "select * from [dbo].[GetOperationCentersInfo]('F')";
    
         SQLHelper a = new SQLHelper(SQLHelper.ConnectionStrings.EmallShippingConnectionString);
    
           int ID = RadComboBox1.SelectedValue; {
           string f1 = "select * from [dbo].[GetReadyDeliveryOrderItems](" + ID + ")";
           DataTable DataTable1 = a.getQueryResult(f1); //Orders Query by OPERATION_CENTER_ID
           DataTable DataTable2 = a.getQueryResult(f2); //Operation centers Query
           DataTable testDataTable = new DataTable();
           rdOrders.DataSource = DataTable1;
           RadComboBox1.DataSource = DataTable2;
           RadComboBox1.DataBind();
    }

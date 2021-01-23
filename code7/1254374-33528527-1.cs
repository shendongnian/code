    protected void Page_Load(object sender, EventArgs e)
    {
        // Initializes a new instance of the DataAccess class 
        DataAccess da = new DataAccess();
        // The styling of the graph
        chart1.Series["Series1"].ChartType = SeriesChartType.Column;
        chart1.Series["Series1"].IsValueShownAsLabel = true;
       
        // The required lines for getting the data from the method in the DataAccess
        chart1.DataSource = da.select_top_sheep(farmerID);
        chart1.Series["Series1"].XValueMember = "SheepID";
        chart1.Series["Series1"].YValueMembers = "Weight";
        chart1.DataBind();
    }

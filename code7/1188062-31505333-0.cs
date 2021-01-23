    //DataSet Company = WebSerivce.Company(IP, DataBaseName, UserName, Password);
    //DataTable cTable = Company.Table[0];
    string conn = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
    SqlDataSource dataSource = new SqlDataSource(conn, "select * from region"); 
    DataSourceSelectArguments args = new DataSourceSelectArguments();
    DataView view = dataSource.Select(args) as DataView;
    DataTable cTable = view.ToTable(); 
    
    if (!Page.IsPostBack)
    {
        DropDownList1.DataSource = cTable;
        DropDownList1.DataValueField = "RegionID";
        DropDownList1.DataTextField = "RegionDescription";
        DropDownList1.DataBind();
    }

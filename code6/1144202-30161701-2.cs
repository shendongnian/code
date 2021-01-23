    DataTable tblModelNames = new DataTable();
    using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LDSTestConnectionString"].ConnectionString))
    using(var da = new SqlDataAdapter("Select ModelName from ProductModel where Div= @Div", con))
    {
        da.Fill(tblModelNames);
        ddlModelName.DataSource = tblModelNames;
    }
    

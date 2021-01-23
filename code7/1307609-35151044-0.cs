    DataSet dsConnection = new DataSet();
    dsConnection.ReadXml(System.Web.Hosting.HostingEnvironment.MapPath("~/ConnectionString.Config.xml"));
    String connection = dsConnection.Tables[0].Rows[0]["connectionstring"].ToString();
    SqlConnectionStringBuilder DBConfig = new SqlConnectionStringBuilder(connection); 
    string ConnectionString = "Data Source=" + Decrypt(DBConfig.DataSource) + ";Initial Catalog=" + Decrypt(DBConfig.InitialCatalog) + ";User ID=" + Decrypt(DBConfig.UserID) + ";Password=" + Decrypt(DBConfig.Password);
    iDB2Connection cn = new iDB2Connection();
    cn.ConnectionString = ConnectionString;

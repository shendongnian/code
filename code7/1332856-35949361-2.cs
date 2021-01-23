    protected void Page_Load(object sender, EventArgs e)
    {
    SqlCommand _sqlCommand1;
    SqlCommand _sqlCommand2;
    SqlCommand _sqlCommand3;
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds2 = new DataSet();
    SqlDataAdapter _sqlDataAdapter1 = new SqlDataAdapter();
    SqlDataAdapter _sqlDataAdapter2 = new SqlDataAdapter();
    SqlDataAdapter _sqlDataAdapter3 = new SqlDataAdapter();
    SqlConnection _sqlDatabaseConnection1;
    SqlConnection _sqlDatabaseConnection2;
    SqlConnection _sqlDatabaseConnection3;
    try
    {
	  _connectionString = System.Configuration.ConfigurationManager.AppSettings[connectionString].ToString();
	  _sqlDatabaseConnection1 = new SqlConnection(_connectionString);
	  _sqlCommand1 = new SqlCommand("SP1", _sqlDatabaseConnection1);
	  _sqlDatabaseConnection1.Open();
	  _sqlCommand1.CommandTimeout = 0;
	  ds1 = new DataSet();
	  _sqlDataAdapter1 = new SqlDataAdapter(_sqlCommand1);
	  _sqlDataAdapter1.Fill(ds1, "Data");
	  return ds1;
	  _sqlDatabaseConnection1.Close();
	  _sqlCommand1.Dispose();
	  _sqlDataAdapter1.Dispose();
	  _connectionString = System.Configuration.ConfigurationManager.AppSettings[connectionString].ToString();
	  _sqlDatabaseConnection2 = new SqlConnection(_connectionString);
	  _sqlCommand2 = new SqlCommand("SP2", _sqlDatabaseConnection1);
	  _sqlDatabaseConnection2.Open();
	  _sqlCommand2.CommandTimeout = 0;
	  ds2 = new DataSet();
	  _sqlDataAdapter2 = new SqlDataAdapter(_sqlCommand1);
	  _sqlDataAdapter2.Fill(ds2, "Data");
	  return ds2;
	  _sqlDatabaseConnection2.Close();
	  _sqlCommand2.Dispose();
	  _sqlDataAdapter2.Dispose();	
	  _connectionString = System.Configuration.ConfigurationManager.AppSettings[connectionString].ToString();
	  _sqlDatabaseConnection3 = new SqlConnection(_connectionString);
	  _sqlCommand3 = new SqlCommand("SP3", _sqlDatabaseConnection1);
	  _sqlDatabaseConnection3.Open();
	  _sqlCommand3.CommandTimeout = 0;
	  ds2 = new DataSet();
	  _sqlDataAdapter3 = new SqlDataAdapter(_sqlCommand1);
	  _sqlDataAdapter3.Fill(ds3, "Data");
	  return ds3;
	  _sqlDatabaseConnection3.Close();
	  _sqlCommand3.Dispose();
	  _sqlDataAdapter3.Dispose();
	
    }
    catch (Exception ex) { }
    }

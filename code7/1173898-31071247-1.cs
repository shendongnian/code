    string strSQLconnection = "Data Source=dbServer;Initial Catalog=testDB;Integrated Security=True";
    SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
    SqlCommand sqlCommand = new SqlCommand("select * from table1", sqlConnection);
    sqlConnection.Open();
     
    SqlDataReader reader = sqlCommand.ExecuteReader();
           
    GridView1.DataSource = reader;
    GridView1.DataBind();

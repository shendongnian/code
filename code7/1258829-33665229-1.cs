    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
    conn.Open();
    string query = "select UserName from Users where lower(Username)=lower('" + CurrentName + "')";
    SqlCommand com = new SqlCommand(query, conn);
    string result = "";
    result = com.ExecuteScalar() == null ? "" : com.ExecuteScalar().ToString();
    conn.Close();
    Response.Write(result);

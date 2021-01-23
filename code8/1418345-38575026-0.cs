        string strQuery;
        SqlCommand cmd;
        strQuery = "insert into customers (CustomerID, CompanyName) values(@CustomerID, @CompanyName)";
        cmd = new SqlCommand(strQuery);
        cmd.Parameters.AddWithValue("@CustomerID", "A234");
        cmd.Parameters.AddWithValue("@CompanyName", "DCB");
    String strConnString = system.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

    try
    {
        using (SqlConnection sourceCnx = new SqlConnection(SOURCE_CONN_STRING))
        {
            sourceCnx.Open();
            SqlCommand sysCmd = sourceCnx.CreateCommand();
            sysCmd.CommandText = "My query";
            sysCmd.ExecuteNonQuery();
        }
    }
    catch(SqlException sqlEx)
    {
        MessageBox.Show("there was a sql issue");
    }
    catch(Exception ex)
    {
        MessageBox.Show("there was some other issue");
    }

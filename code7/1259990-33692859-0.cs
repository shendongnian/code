    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionName"].ConnectionString;
    SqlCommand cmd = new SqlCommand("procedure_name", con);
    cmd.Parameters.Add("@mark", SqlDbType.NVarChar).Value = your_value;
    cmd.CommandType = CommandType.StoredProcedure;
    con.Open();
    cmd.ExecuteNonQuery();
    string result = cmd.Parameters["Vle"].Value.ToString();
    con.Close();

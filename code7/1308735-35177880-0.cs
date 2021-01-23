    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EADPRJConnectionString"].ConnectionString))
    {
        string sql = @"SELECT CAST(CASE WHEN EXISTS(SELECT 1 FROM Patient
                                                    WHERE PNRIC = @PNRIC)
                                   THEN 1 ELSE 0 END AS BIT)";
        using (var myCommand = new SqlCommand(sql, con))
        {
            myCommand.Paramaters.Add("@PNRIC", SqlDbType.NVarChar).Value = tbNRIC.Text;
            con.Open();
            bool deleted = (bool)myCommand.ExecuteScalar();
            // ...
        }
    }

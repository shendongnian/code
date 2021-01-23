        SqlConnection con = new SqlConnection("<<ConnectionStringValue>>");
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SPTest";
        com.Parameters.Add("@model", SqlDbType.NVarChar, 20).Value = "<Parameter Value>";
        SqlDataReader reader = com.ExecuteReader();
        Rest Of Code Goes Here
        ...
        ...
        ...

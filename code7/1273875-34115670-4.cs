    System.Data.SqlClient.SqlCommand scom = new System.Data.SqlClient.SqlCommand("CDRCOLLECT", sqlConnection);
    scom.CommandType = System.Data.CommandType.StoredProcedure;
    scom.Parameters.Add("@fName", System.Data.SqlDbType.NVarChar);
    scom.Parameters.Add("@lName", System.Data.SqlDbType.NVarChar); scom.Parameters["@fName"].Value = TextBox1.Value;
    scom.Parameters["@lName"].Value = TextBox2.Value;
    scom.ExecuteNonQuery();

    InsertQuery = "LicenseInsert"; // Query to insert into the database table.
    SqlCommand cmd = new SqlCommand(InsertQuery, con);
    cmd.CommandType = CommandType.StoredProcedure;  // <------------
    cmd.Parameters.Add("@LicensingKey", SqlDbType.Int).Value = LicensingKey;  
    cmd.Parameters.Add("@OrgID", SqlDbType.Int).Value = OrgID;
    cmd.ExecuteNonQuery();

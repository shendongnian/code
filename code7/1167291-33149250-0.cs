    try
    {
        dbConn.Open();
    } catch (Exception)
    {
        mRtnVar = "Couldn't Connect";
        return mRtnVar
    }   
    string sqlstr = string.Format(@"SELECT ""FieldName"" FROM PUB.DataBase WHERE ""FieldName"" = 'value'");
    using (OdbcCommand comm = new OdbcCommand(sqlstr, dbConn))
    {
        using (OdbcDataReader reader = dbConn.ExecuteReader())
        {
            if (reader.Read())
            {
                mRtnVar = reader["FieldName"].ToString();
            }
        }
    } 
    return mRtnVar
}      

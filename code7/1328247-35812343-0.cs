    if(fasting)
    {
        insertCommand.Parameters.Add("@param2", System.Data.SqlDbType.Int).Value = "1";
    }
    else
    {
        insertCommand.Parameters.Add("@param2", System.Data.SqlDbType.Int).Value = "0";
    }

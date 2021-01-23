    try
    {
        if(sqlDataReader.IsDBNull(0))
        {
           // deal with null
        }
        else  
        {
          Int32 id = sqlDataReader.GetInt32(0);
        }
    }
    catch (SQLexception Ex) 
    {
        Debug.WriteLine(Ex.message);
    }

    try
    { 
        cn.Open();
        string firstName = "not";
        string lastName = "found";
        using (SQLDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            if (dr.Read())  //if there is a row, there are two columns. Thus index is used below
            {
                Debug.WriteLine(dr.FieldCount);
                firstName = rdr.IsDBNull(0) ? string.Empty : rdr.GetString(0);
                lastName = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);                         
            }
        }
    } 
    catch (SqlException ex)
    {
        Debug.WriteLine("GetUser " + Environment.NewLine + ex.Message);
    }
    catch (Exception ex)
    {
        Debug.WriteLine("GetUser" + Environment.NewLine + ex.Message);
        throw ex;
    }
    finally
    {
        cn.Close();
    }
    return firstName + " " + lastName;

    try
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("usp_Get_ProductDetails", con);
            .....
        }
    }
    catch(FaultException faultEx)
    {
        // code to send to client
    }
    catch(Exception ex) 
    {
        // code to do something else
    }

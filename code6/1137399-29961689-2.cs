    protected int getFlightOnward(int flightId) 
    {
        int id_flight_onward = -1;
        
        string connection_string = /* get database infos */;
        SqlConnection con = new SqlConnection(connection_string);
    
        try 
        {
            con.Open(); 
            SqlCommand com = new SqlCommand("your_procedure_name", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@sql_flight_id", flightId);
            SqlParameter return_value = com.Parameters.Add("@sql_return", SqlDbType.Int);
            return_value.Direction = ParameterDirection.Output;
    
            com.ExecuteNonQuery();
    
            id_flight_onward = int.Parse(com.Parameters["@sql_return"].Value.ToString());
        }
        catch 
        {
            con.Close();
        }
    
        return id_flight_onward;
    }

    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        string bruker = Request.Cookies["Navn"].Value;
        string mobilnr = Request.Cookies["Mobilnr"].Value;
 
        string commandText = "SELECT Engangskode FROM Brukere WHERE Navn=@navn AND Mobilnr=@mobilnr";
 
        bool correctCode = false;
 
        try
        {
            using (SqlCommand command = new SqlCommand(commandText, con))
            {
                .....
                
                if (correctCode)
 		        {
 		            // DO NOT "reuse" the previous SqlCommand - create a new, specific one!
		            string updateQuery = "UPDATE Brukere SET Engangskode = NULL WHERE Navn = @navn AND Mobilnr = @mobilnr;";
		    
		            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con)
                    {
	    	            updateCmd.Parameters.Add("@navn", SqlDbType.NVarChar, 20).Value = bruker;
                        updateCmd.Parameters.Add("@mobilnr", SqlDbType.NChar, 10).Value = mobilnr;
		    
		                updateCmd.ExecuteNonQuery();
		 
		                Response.Redirect("Kvittering.aspx",  false);
                    }
                }
            }		                             
        }
        catch( .... )
        {
            .......
        }
    }            

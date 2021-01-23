    using (var con = new SqlConnection(cnString))
    {
    
    	con.Open();
    	
    	using (var cmd = new SqlCommand("select * from fees where admno = @admno", con))
    	{
    		cmd.Parameters.Add("@admno", SqlDbType.Varchar, "");
    		using (var reader = cmd.ExecuteReader())
    		{			
    			return reader.Select(r => new 
    						  {
    							  TutionFee= r["tutionfee"] is DBNull ? null : r["tutionfee"].ToString(),
    							  ComputerFee= r["computerfee"] is DBNull ? null : r["computerfee"].ToString(),
    							  AdmissionFee= r["admissiofee"] is DBNull ? null : r["admissiofee"].ToString()
    						  }).ToList();
    			
    		}
    	}
    }

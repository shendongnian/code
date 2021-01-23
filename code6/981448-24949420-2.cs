     SqlConnection con = dBClass.SqlConnection(); // return the connection string 
        
        SqlDataAdapter da = new SqlDataAdapter("[LC_PR_R_TRN_test]", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        
        da.SelectCommand.Parameters.Add("@plong_ID", SqlDbType.BigInt).Value = ID;
                       
        
                        DataSet result = new DataSet();
                        da.Fill(result);

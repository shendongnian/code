    public  DataTable  GetApprovedData(ref string tablename)  
    {
       dtTbl = new DataTable();
       try 
       {	        
           if (cnn.State==System.Data.ConnectionState.Closed)
           {
               cnn.Open();
               cmd = new  SqlCommand("USP_Billing_GetApprovedData", cnn);
               cmd.CommandTimeout = 5000;
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@ProcessName", tablename);
                               
               da = new SqlDataAdapter(cmd);
               da.Fill(dtTbl);
               
            }
        }
        catch (Exception ex)
        {
           MessageBox.Show(ex.Message);
        }   
    
        return dtTbl;
    }
 

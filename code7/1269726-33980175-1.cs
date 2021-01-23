    using (SqlConnection Sqlcon = new SqlConnection(strCon))    
    {    
    using (SqlCommand cmd = new SqlCommand())    
    {
    
    Sqlcon.Open();
    
    cmd.Connection = Sqlcon;
    
    cmd.CommandType = CommandType.StoredProcedure;
    
    cmd.CommandText = "GetCustomerProductsById";
    
    cmd.Parameters.Add(new SqlParameter("@CustId", SqlDbType.Int, 50));
    
    cmd.Parameters["@CustId"].Value = <Your Input Source>;  
    SqlAda = new SqlDataAdapter(cmd);
    
    ds = new DataSet();
    
    SqlAda.Fill(ds);
    
    Datatable dt = new DataTable();
    dt = ds.Tables[0];
    }
    
    }

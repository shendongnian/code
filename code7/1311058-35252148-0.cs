    using (SqlCommand cmd1 = new SqlCommand("spG_Groups", conn))
    {
         cmd1.CommandType = CommandType.StoredProcedure;
         // define the parameters *ONCE*
         cmd1.Parameters.Add("@CName", SqlDbType.NVarChar, 450);
         cmd1.Parameters.Add("@CEmail", SqlDbType.VarChar, 250);
         cmd1.Parameters.Add("@GName", SqlDbType.NVarChar, 70);
    
         List<String> YrStrList1 = new List<string>(); 
    
         foreach (ListItem li in chGp.Items)
         {
             if (li.Selected)
             {
                  YrStrList1.Add(li.Value);
    
                  // just set the *VALUES* of the parameters
                  cmd1.Parameters["@CName"].Value = txtCName.Value;
                  cmd1.Parameters["@CEmail"].Value = txtemail.Value;
                  cmd1.Parameters["@GName"].Value = YrStrList1.ToString();
    
                  cmd1.ExecuteNonQuery();
             }
         }
    }

    private void InsertPdtLocal(string code, string PON,string Qty)
            {
                string str = Properties.Settings.Default.conLocal;
                try
                {
                
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd =  con.CreateCommand())
                    {
                         cmd.Parameters.AddWithValue("@PON", PON);
                         cmd.Parameters.AddWithValue("@Qty", Qty);
                         cmd.Parameters.AddWithValue("@TCode", code);
                         cmd.Parameters.AddWithValue("@Type", Globals.s_type);
                         var output = cmd.Parameters.Add("@RES" , SqlDbType.Int);
                         output.Direction  = ParameterDirection.Output;
                         cmd.ExecuteNonQuery();
                         int id = Convert.ToInt32(output.Value);
                    }
                }
    
                }
                 catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
               
    
     
     

    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ConnectionString))            
    {
        GridView gv = sender as GridView;
        using (SqlCommand cmd = new SqlCommand("dbo.SP_DynamicUpdate", con))
        {                    
            #region Parameters                                        
        	cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@col", e.Column.FieldName);                    
            cmd.Parameters.AddWithValue("@val", e.Value);
            cmd.Parameters.AddWithValue("@id", gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]));
            #endregion
             try
             { 
        		con.Open();
        		cmd.ExecuteNonQuery(); 
        	 }
             catch (Exception xe)
             { 
        		MessageBox.Show(xe.Message); 
        	 }                     
         }     
     } 
 

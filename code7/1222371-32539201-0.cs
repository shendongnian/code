    private void add(int cc, int cv, int cs, int cr,int usag,int isecure, string ds, string de)
    
            {
                using (MySqlConnection cn = new MySqlConnection(connectionstring))
                {
                 cn.open();
                 using (var sqlcmd = new SqlCommand(cn))
                 {
                   sqlcmd.Parameters.AddWithValue("@codeCust", cc);
                   sqlcmd.Parameters.AddWithValue("@codeVendor", cv);
                   sqlcmd.Parameters.AddWithValue("@codeService", cs);
                   sqlcmd.Parameters.AddWithValue("@codeRegion", cr);
                   sqlcmd.Parameters.AddWithValue("@Usages", usag);
                   sqlcmd.Parameters.AddWithValue("@isSecure", isecure);
                   sqlcmd.Parameters.AddWithValue("@dateStart", Convert.ToDateTime(ds));
                   sqlcmd.Parameters.AddWithValue("@dateEnd", Convert.ToDateTime(de));
                   var query_result = sqlcmd.ExecuteNonQuery();	
                 }
               }
            }

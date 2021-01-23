    private void add(int cc, int cv, int cs, int cr,int usag,int isecure, string ds, string de)
    
            {
                using (MySqlConnection cn = new MySqlConnection(connectionstring))
                {
                 using (var sqlcmd = new SqlCommand())
                 {
                   sqlcmd.Connection = cn;
                   sqlcmd.CommandText = "insert into tblusage(codeCust,codeVendor,codeService,codeRegion,Usages,isSecure,dateStart,dateEnd) values (@codeCust,
			@codeVendor, @codeService, @codeRegion, @Usages, @isSecure, @dateStart, @dateEnd)")
                   sqlcmd.Parameters.AddWithValue("@codeCust", cc);
                   sqlcmd.Parameters.AddWithValue("@codeVendor", cv);
                   sqlcmd.Parameters.AddWithValue("@codeService", cs);
                   sqlcmd.Parameters.AddWithValue("@codeRegion", cr);
                   sqlcmd.Parameters.AddWithValue("@Usages", usag);
                   sqlcmd.Parameters.AddWithValue("@isSecure", isecure);
                   sqlcmd.Parameters.AddWithValue("@dateStart", Convert.ToDateTime(ds));
                   sqlcmd.Parameters.AddWithValue("@dateEnd", Convert.ToDateTime(de));
                   cn.open();
                   sqlcmd.ExecuteNonQuery();	
                 }
               }
            }

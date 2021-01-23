     private void add(int cc, int cv, int cs, int cr,int usag,int isecure, string ds, string de)
    
            {
    
                using (MySqlConnection cn = new MySqlConnection(connectionstring))
                {
    
                    string query = "insert into tblusage(codeCust,codeVendor,codeService,codeRegion,Usages,isSecure,dateStart,dateEnd) values (@cc,@cv,@cs,@cr,@usag,@isecure,@ds,@de) ";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd .Parameters.Add("@cc",MySqlDbType.Int).Value=cc;
                    cmd .Parameters.Add("@cv",MySqlDbType.Int).Value=cv;
                    cmd .Parameters.Add("@cs",MySqlDbType.Int).Value=cs;
                    cmd .Parameters.Add("@cr",MySqlDbType.Int).Value=cr;
                    cmd .Parameters.Add("@usag",MySqlDbType.Int).Value=usag;
                  cmd .Parameters.Add("@isecure",MySqlDbType.Int).Value=isecure;
                    cmd .Parameters.Add("@ds",MySqlDbType.Date).Value=ds;
                    cmd .Parameters.Add("@de",MySqlDbType.Date).Value=de;
           
                    cn.Open();
                    cmd.ExecuteNonQuery();
    
                }
            }

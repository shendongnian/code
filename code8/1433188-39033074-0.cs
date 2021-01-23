    SqlCommand cmdadmin = new SqlCommand("loginvalidation");
    cmdadmin.Connection = con;
    cmdadmin.CommandType = CommandType.StoredProcedure;
    SqlParameter[] parameters ={
                             new SqlParameter("vtype",drd1.ToString()),
                             new SqlParameter("username",Label1.Text),
                            };
    foreach (var p in parameters)
       {   
           cmdadmin.Parameters.Add(parameters);
       }
    	

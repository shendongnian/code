            SqlCommand cmdadmin = new SqlCommand("loginvalidation");
            cmdadmin.Connection = con;
            cmdadmin.CommandType = CommandType.StoredProcedure;
            SqlParameter[] prms = new SqlParameter[] 
            {
                new SqlParameter("@vtype", drd1.ToString()),
                new SqlParameter("@username", Label1.Text)
            };
            cmdadmin.Parameters.AddRange(prms);

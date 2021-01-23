            int a = 1;
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "SELECT * FROm somwhere";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            if (a == 1)
            {`enter code here`
                SqlParameter sqlParam1 = new SqlParameter();
                lstParams.Add(sqlParam1);
            }
            else if (a == 2)
            {
                SqlParameter sqlParam2 = new SqlParameter();
                lstParams.Add(sqlParam2);
            }
            sql.Parameters.AddRange(lstParams.ToArray());
            sql.BeginExecuteReader();

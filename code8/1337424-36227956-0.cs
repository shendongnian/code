     public void data_insert()
        {
            string connstr = "User Id=user;Password=pwd;";
            string cmdtxt = @"insert into customers 
                              (CUST_ID,F_NAME,CUST_PHONE1,CUST_PHONE2,EMAIL)
                              values (null,:TB_NAME,:TB_PHONE1,:TB_PHONE2,:TB_EMAIL)
                              RETURNING CUST_ID into :OUT_ID";
            using (OracleConnection conn = new OracleConnection(connstr))
            using (OracleCommand cmd =new OracleCommand(cmdtxt,conn))
            {
                cmd.Parameters.Add(new OracleParameter("TB_NAME", TB_NAME.Text));
                cmd.Parameters.Add(new OracleParameter("TB_PHONE1", TB_PHONE1.Text));
                cmd.Parameters.Add(new OracleParameter("TB_PHONE2", TB_PHONE2.Text));
                cmd.Parameters.Add(new OracleParameter("TB_EMAIL", TB_EMAIL.Text));
                cmd.Parameters.Add(":OUT_ID", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.CommandText = cmdtxt;
                conn.Open();
                cmd.ExecuteNonQuery();
                TB_CUST_ID.Text = (cmd.Parameters[":OUT_ID"].Value).ToString();
            }
        }

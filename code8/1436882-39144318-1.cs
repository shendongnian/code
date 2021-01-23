            dtcmd.Connection = myconn;
            dtcmd.CommandText = "SELECT Name, EmailId FROM sample WHERE [id] = '" + find_tb.Text + "'";
            if (myconn.State == ConnectionState.Closed)
            {
                myconn.Open();
            }
            OleDbDataReader dr = dtcmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    email_tb.Text = dr["EmailId"].ToString();
                }
            }
            dr.Close();
            myconn.Close();

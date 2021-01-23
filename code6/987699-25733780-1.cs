              using (con)
            {
                con.Open();
                SqlDataAdapter cmd1 = new SqlDataAdapter();
                cmd1 = new SqlCommand(sql1, con);
                cmd1.InsertCommand.Parameters.Add("@id", SqlDbType.Int).Value = threadId;
                cmd1.InsertCommand.Parameters.Add("@poster", SqlDbType.NVarChar).Value = tempPoster;
                cmd1.InsertCommand.ExecuteNonQuery();
                SqlDataAdapter cmd2 = new SqlDataAdapter();
                cmd2 = new SqlCommand(sql2, con);
                cmd2.InsertCommand.Parameters.Add("@Cid", SqlDbType.Int).Value = commendId;
                cmd2.InsertCommand.Parameters.Add("@Ccontent", SqlDbType.Nvarchar).Value = txt;
                cmd2.InsertCommand.Parameters.Add("@Cupload", SqlDbType.Nvarchar).Value = fname.ToString();
                cmd2.InsertCommand.Parameters.Add("@Tid", SqlDbType.Int).Value = topicId;
                cmd2.InsertCommand.Parameters.Add("@Thid", SqlDbType.Int).Value = threadId;
                cmd2.InsertCommand.ExecuteNonQuery();
            }

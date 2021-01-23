               using (con)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.Parameters.Add("@id", SqlDbType.Int).Value = threadId;
                cmd1.Parameters.Add("@poster", SqlDbType.NVarChar).Value = tempPoster;
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.Parameters.Add("@Cid",SqlDbType.Int).Value= commendId;
                cmd2.Parameters.Add("@Ccontent",SqlDbType.Nvarchar).Value= txt;
                cmd2.Parameters.Add("@Cupload", SqlDbType.Nvarchar).Value = fname.ToString();
                cmd2.Parameters.Add("@Tid", SqlDbType.Nvarchar).Value = topicId;
                cmd2.Parameters.Add("@Thid", SqlDbType.Nvarchar).Value = threadId;
                cmd2.ExecuteNonQuery();
            }

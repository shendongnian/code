        for (int i = 0; i < res.Count; i++)
        {
            newcmd.Parameters.Clear();
            newcmd.Parameters.Add("@frmcat", res[i]);
            SqlDataReader sdr = newcmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    cl.Add(sdr["company"].ToString());
                }
            }
            sdr.Close();
            sdr.Dispose();
        }

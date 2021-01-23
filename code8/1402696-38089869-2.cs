    using MySql.Data.MySqlClient;
    string connString = @"server=localhost;userid=drew;password=OpenSesame;database=stackoverflow";
.
            long lRet = 0;
            using (MySqlConnection lconn = new MySqlConnection(connString))
            {
                lconn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = lconn;
                    cmd.CommandText = @"select count(*) as theCount from batchQMetricsToUpdate where status=1";
                    lRet = (long)cmd.ExecuteScalar();
                }
            }
            return(lRet);

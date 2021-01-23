            string connectionString = ConfigurationManager.ConnectionStrings["PBReportCS"].ConnectionString;
            string commandTimeOut = ConfigurationManager.AppSettings["PBReportCommandTimeout"].ToString();
            DataSet result = new DataSet();
            string pDate = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.CommandTimeout = int.Parse(commandTimeOut);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(result);
                        adapter.Dispose();
                        conn.Close();
                        pDate = result.Tables[0].Rows[0]["PDate"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return pDate;
}

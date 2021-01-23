    public DataSet GetDataSetExportToExcel()
        {
            DataSet ds = new DataSet();
            var SPNames = new List<string>() { "storedproc1", "storedproc2" };
            foreach (var SPName in SPNames)
            {
                DataTable dt = new DataTable();
                dt = GetDataTableExportToExcel(SPName);
                ds.Tables.Add(dt);
            }
            return ds;
        }
        private DataTable GetDataTableExportToExcel(string SPName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(SPName, con))
                {
                    using (var sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

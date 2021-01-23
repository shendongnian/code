        public static System.Data.DataTable LazyGetDataTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = "lalala - Not really necessary";
            using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM YOUR_TABLE", "YOUR CONNECTION STRING HERE"))
            {
                da.Fill(dt);
            }
            return dt;
        } // End Function LazyGetDataTable

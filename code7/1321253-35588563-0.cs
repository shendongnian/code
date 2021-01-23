        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static List<events> elist(int catId)
        {
            List<events> eve = new List<events>();
            eve = (from DataRow row in dt2(catId).Rows
                   select new events
                   {
                       EVE_NAME = row["EVE_NAME"].ToString(),
                       EVE_IMG_URL = row["EVE_IMG_URL"].ToString(),
                       EVE_DESCRIPTION_SHORT = row["EVE_DESCRIPTION_SHORT"].ToString(),
                   }).ToList();
            return eve;
        }
        public static DataTable dt2(int catId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=EVENT;Persist Security Info=True;User ID=sa;Password = 123");
            string query = "sp_view";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@catID", SqlDbType.Int).Value = catId;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            return dataTable;
        }

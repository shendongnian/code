        SqlConnection con = new SqlConnection("Here Copy your connection string");
        
        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public string GetData()
        {
            var json = "";
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbldemo",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> lst1 = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns )
                {
                    lst1.Add(dc.ColumnName,row[dc]);
                }
                lst.Add(lst1);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            json = js.Serialize(lst);
            return json;
        }

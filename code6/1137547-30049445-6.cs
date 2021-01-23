        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string[] GetKeywords()
        {
            List<string> lst = new List<string>();
            string queryString = "select * from SIB_KWD_Library ORDER BY Keyword asc";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["vConnString"].ToString()))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(reader["Keyword"].ToString());
                        }
                    }
                }
            }
            return lst.ToArray();
        }

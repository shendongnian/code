    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static List<string> GetKeywords()
    {
        List<string> lst = new List<string>();
        string queryString = "select Keyword from SIB_KWD_Library";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["vConnString"].ToString()))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(reader["Keyword"].ToString());
                    }
                }
            }
        }
        lst = lst.ConvertAll(d => d.ToLower());
        return lst; //return it as list itself
    }

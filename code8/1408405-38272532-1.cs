     public string DoUserExist(string Emailaddress)
        {
            bool ch = false;
            string connectionString = ConfigurationManager.ConnectionStrings["FreelanceDBCS"].ConnectionString;
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("GetCities", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        con.Open();    
        using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<getCities> _getCities= new List<getCities>();
                while (reader.Read())
                {
                    getCities cities= new getCities();
                    cities.Data.Add(int.Parse(reader["col2"].ToString()));
                    cities.Data.Add(int.Parse(reader["col3"].ToString()));
                    cities.Data.Add(int.Parse(reader["col4"].ToString()));
                    _getCities.Add(cities);
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                jsonString = jss.Serialize(_getCities);
            }
        }
    
    return jsonString;  
    }
     

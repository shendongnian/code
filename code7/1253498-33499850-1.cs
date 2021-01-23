    [WebMethod]
        public static List<string> GetCities(string cityName)
        {
            List<string> City = new List<string>();
            string query = string.Format("SELECT DISTINCT City FROM Customers WHERE City LIKE '%{0}%'", cityName);
            //Note: you can configure Connection string in web.config also.
            using (SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS2008R2; initial Catalog = NORTHWND; Integrated Security = true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        City.Add(reader.GetString(0));
                    }
                }
            }
            return City;
        }

    public string getCityPopulation(List<string> pData)
    {
        StringBuilder sb = new StringBuilder();
        string myQuery = "SELECT city_name, population FROM tb_city_population WHERE (year_of = @year)";
        using (SqlConnection connection = new SqlConnection(Common.connectionString))
        using (SqlCommand command = new SqlCommand(myQuery, connection))
        {
            command.Parameters.AddWithValue("@year", pData[0]);
            try
            {
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        sb.Append("[");
                        sb.Append("'" + dr["city_name"].ToString() + "'");
                        sb.Append(", ");
                        sb.Append(dr["population"].ToString().Replace(",", "."));
                        sb.Append("],");
                    }
                }
            }
            catch
            {
                //error connecting\reading the database
            }
        }
        return "[ " + sb.ToString().TrimEnd(',') + " ]";
    }

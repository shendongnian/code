    public static SqlCommand Avreg(string s, string t, string p, string c, string d, SqlConnection connection)
    {
        try
        {
            var query = "UPDATE ...."
            SqlCommand command1 = new SqlCommand();
    
    
    
            if (c == "0")
            {
                query += ", CitizenshipDate = null";
            }
            else
            {
                query += ", CitizenshipDate = @CitizenshipDate";
                command1.Parameters.AddWithValue("@CitizenshipDate", c ?? DBNull.Value.ToString());
            }
    
            if (d == "0")
            {
                query += ", NationalRegistrationDate = null;";
            }
            else
            {
                query += ", NationalRegistrationDate = @NationalRegistrationDate";
                DateTime myDate = DateTime.ParseExact(d, "yyyyMMdd",
                System.Globalization.CultureInfo.InvariantCulture);
                command1.Parameters.AddWithValue("@NationalRegistrationDate", myDate);
            }
            command1.CommandText = query;
            command1.Connection = connection;
        }
        return command1;
    }

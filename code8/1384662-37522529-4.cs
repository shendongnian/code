    public static void Avreg(SqlCommand command1, string s, string t,
                  string p, string c, string d)
    {
        var query = "UPDATE....";
        if (c == "0")
        {
            query += ", CitizenshipDate = null";
        }
        else
        {
            query += ", CitizenshipDate = @CitizenshipDate";
            if(!command1.Parameters.Contains("@CitizenshipDate"))
                 command1.Parameters.Add("@CitizenshipDate", SqlDbType.NVarChar);
            command1.Parameters["@CitizenshipDate"].Value = string.IsNullOrEmpty(c) ? DBNull.Value : (object)c);
        }
        .....
    }

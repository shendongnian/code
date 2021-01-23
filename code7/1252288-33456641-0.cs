    public static string GetDetails(int Id)
    {
        string con = "server=FACULTY01\\SQLSERVER2012ENT; database=SampleDb; uid=sa; pwd=sa9";
        using (SqlConnection scon = new SqlConnection(con))
        {
            string qry = "Select * from Information where ID = @id";
            SqlCommand cmd = new SqlCommand(qry, scon);
            cmd.Parameters.AddWithValue("@id", Id);
            scon.Open();
            var details = new Dictionary<string, object>();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows && rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        details.Add(rdr.GetName(i), rdr.IsDBNull(i) ? null : rdr.GetValue(i));
                    }
                }
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonDoc = jss.Serialize(details);
            scon.Close();
            return jsonDoc;
        }
    }

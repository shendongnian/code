    public IEnumerable<Events> Collection()
    {
        string address = "YourConnectionString";
        using (SqlConnection con = new SqlConnection(address))
        {
            con.Open();
            string qry = "select * from Events";
            SqlCommand cmd = new SqlCommand(qry, con);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (!dr.HasRows) yield break;
                while (dr.Read())
                {
                    Events evt = new Events
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        EvtName = dr["EvtName"].ToString(),
                        EvtType = dr["EvtType"].ToString(),
                        EvtImage = dr["EvtImage"].ToString()
                    };
                    yield return (evt);
                }
            }
        }
    }

    protected IEnumerable<string> Collection()
    {
        string address = ConfigurationManager.ConnectionStrings["blogconnection"].ToString();
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
                    if (!string.IsNullOrEmpty(Convert.ToString(dr["EvtImage"])))
                    {
                        yield return (dr["EvtImage"].ToString());
                    }
                 }
             }
         }
    }

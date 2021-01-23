    using(SqlConnection con = new SqlConnection("Connection String Here"))
        {
            string myQuery = "Your Query";
            using(SqlCommand cmd = new SqlCommand(myQuery, con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    con.Open();
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                }
            }
        }

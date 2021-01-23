    var connStr = "YourConnectionStringHere"
    using (var c = new SqlConnection(connStr))
    {
        using (var cmd = new SqlCommand(c, "SELECT * FROM ITEMS"))
        {
            c.Open();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    //read from reader now
                    //ItemList.Items.Add(dr[0].ToString());
                }
            }
        }
      //No need to explicitly close connection :) Thanks to "using"
    }

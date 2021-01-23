    using (var con = new SqlConnection(constr))
    {
        con.Open();
        string query = "SELECT [OBJECTID] from dbo.OWNER where [owner_id] = @OwnerID";
        using (var com = new SqlCommand(query, con))
        {
            com.Parameters.AddWithValue("@OwnerID", Login1.UserName);
            using (var da = new SqlDataAdapter(com))
            {
                var ds = new DataSet();
                da.Fill(ds);
                Console.WriteLine(ds.Tables[0].Rows[0][0]);
            }
        }
    }

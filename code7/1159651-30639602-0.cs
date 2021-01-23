     SqlConnection con = new SqlConnection("");
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection cmd = new SqlConnection();
            DataTable dt = new DataTable();
                da.SelectCommand = con.CreateCommand();
                da.SelectCommand.CommandText="UPDATE ItemPlayerConnection SET Inventory=TRUE WHERE Player="+player+" AND Item="+itemID);
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt);

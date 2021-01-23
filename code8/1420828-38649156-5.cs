    protected void repeater1_DataBinding(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(...))
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clients ORDER BY ID", conn))
        {
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            int halfCount = dt.Rows.Count / 2;
            dtTopHalf = dt.AsEnumerable().Select(x => x).Take(halfCount).CopyToDataTable();
            dtBottomHalf = dt.AsEnumerable().Select(x => x).Skip(halfCount).CopyToDataTable();
        }
    }

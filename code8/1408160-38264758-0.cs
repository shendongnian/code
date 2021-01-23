    var da = new SqlDataAdapter("Your Command", @"Your Connection String");
    da.SelectCommand.Parameters.AddWithValue("@UserName", textBox1.Text);
    da.SelectCommand.Parameters.AddWithValue("@Password", textBox2.Text);
    var dt = new DataTable();
    da.Fill(dt);
    if (dt.Rows.Count == 1)
    {
        int id = dt.Rows[0].Field<int>("Id");
        string userName = dt.Rows[0].Field<string>("UserName");
    }

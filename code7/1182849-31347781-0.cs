    comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = @"SELECT DISTINCT Mobile
                            FROM Client_Details
                            WHERE Branch = @Branch";
        cmd.Parameters.AddWithValue("@Branch", label2.Text);
        try
        {
            var dt = new DataTable();
            dt.Columns.Add("Mobile", typeof(string));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DataRow row = dt.NewRow();
            row["Mobile"] = "<Select>";                    
            dt.Rows.InsertAt(row, 0);
            comboBox1.DisplayMember = "Mobile";
            comboBox1.DataSource = dt;
            comboBox1.SelectedItem = "<Select>";
        }
        catch
        {
            throw;
        }
    }

    public void getData(string query, string year, string month, excel.Worksheet Ws)
    {
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@YR", year);
        cmd.Parameters.AddWithValue("@MN", month);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        int row = 1;
        SqlDataReader reader = cmd.ExecuteReader();
        for (int col = 0; col < reader.FieldCount; col++)
            Ws.Cells[col + 1, 1].Value2 = reader.GetName(col);
        while (reader.Read())
        {
            for (int col = 0; col < reader.FieldCount; col++)
                if (!reader.IsDBNull(col))
                    Ws.Cells[row, col + 1] = reader.GetValue(col);
            row++;
        }
        reader.Close();
    }

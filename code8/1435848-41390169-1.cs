    SqlCommand cmd = func.getData("sp_MRR_Retention_APAC", Yr, mn);
    SqlDataReader reader = cmd.ExecuteReader();
    for (int col = 0; col < reader.FieldCount; col++)
        xlWorkSheet.Cells[col + 1, 1].Value2 = reader.GetName(col);
    while (reader.Read())
    {
        for (int col = 0; col < reader.FieldCount; col++)
            if (!reader.IsDBNull(col))
                xlWorkSheet.Cells[row, col + 1] = reader.GetValue(col);
        row++;
    }
    reader.Close();

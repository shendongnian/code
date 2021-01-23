    private void CaricaNoteLavaggio()
    {
        using (DatabaseConnection db = new DatabaseConnection())
        {
            const string query = "" // My query
            using (MySqlDataReader reader = db.ExecuteReader(query))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                                {
                                    cell.Value = "LOL";
                                }
                               
                        dataGridNoteLavaggio.Rows.Add(row);                    
                    }
                }
            }
        }
    }

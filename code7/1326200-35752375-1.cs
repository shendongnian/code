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
                        var index = dataGridNoteLavaggio.Rows.Add(row);
                        foreach (DataGridViewCell cell in dataGridNoteLavaggio.Rows[index].Cells)
                        {
                            cell.Value = "LOL";
                        }
                    }
                }
            }
        }
    }

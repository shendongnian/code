    foreach (DataColumn dc in allCheckboxes.Columns)
    {
        string Query = $"UPDATE agenda.exercises SET {dc.ToString()} = @True 
                         WHERE Date = @CurrentDate;";
        using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
        {
            using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
            {
                MyCommand2.Parameters.AddWithValue("@True ", true);
                MyCommand2.Parameters.AddWithValue("@CurrentDate", currentDate);
                MyConn2.Open();
                MyCommand2.ExecuteNonQuery();
            }
        }
    }

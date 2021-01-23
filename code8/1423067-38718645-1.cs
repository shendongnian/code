    foreach (DataColumn col in allCheckboxes.Columns)
    {
        string Query = "update agenda.exercises set " + col.ToString() + " = @value where Date = @CurrentDate;";
        using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
        {
            using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
            {
                MyCommand2.Parameters.AddWithValue("@Value ", true);
                MyCommand2.Parameters.AddWithValue("@CurrentDate", currentDate);
                MyConn2.Open();
                MyCommand2.ExecuteNonQuery();
            }
        }
    }

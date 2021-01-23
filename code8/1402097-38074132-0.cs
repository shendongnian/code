    private void buttonLoginClick(object sender, EventArgs e)
    {
        try
        {
            using (var sqLiteConnection = new SQLiteConnection(connString))
            {
                sqLiteConnection.Open();
                using (var sqLiteCommand = new SQLiteCommand(sql, sqLiteConnection))
                {
                    sqLiteCommand.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Success");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
    }

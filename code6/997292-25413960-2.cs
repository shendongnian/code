    private void btnTestTableInsert_Click(object sender, EventArgs e)
    {
        int rowsAffected = 0;
        String bigInsert = "";
        bigInsert = "INSERT INTO iminvtrx_sql_i(item_no, totalTransactions, compileDate)";
    
        for (int i = 0; i < 2100; i++)
        {
           rowsAffected += addToDatabase(i);
        }
    
        MessageBox.Show(string.Format("There were {0} added to the table!", rowsAffected.ToString()));
    }
    private int addToDatabase(int count)
    {
        int rowsAffected = 0;
        string insertString = "";
        SqlConnection connection = finder.getConnectionFor("data_01");
        SqlCommand command = connection.CreateCommand();
    
        insertString = "BEGIN TRANSACTION INSERT INTO iminvtrx_sql_i(item_no, totalTransactions, compileDate) VALUES('test', 1.0, @increment) COMMIT TRANSACTION";
        command.CommandText = insertString;
        command.Parameters.AddWithValue("@increment", count);
    
        try
        {
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
            rowsAffected++;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, ex.InnerException.ToString());
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    
        return rowsAffected;
    }

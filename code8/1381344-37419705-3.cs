    try
    {    
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
    }
    catch (Exception e)
    {
        MessageBox.Show("Error: " + e);
    }
        sqlConnection1.Close();

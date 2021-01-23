    try
    {
        ...
        SqlCommand com = new SqlCommand(queryStr, conn);
        com.ExecuteNonQuery();
        conn.Close();
        ...
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }

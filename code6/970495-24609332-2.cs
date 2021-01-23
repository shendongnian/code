    cmd  = new SqlCommand(query, conn);
    ... // lots of code
    cmd  = new SqlCommand(query, conn);
    try
    {
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }

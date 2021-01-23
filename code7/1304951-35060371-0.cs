     try
        {
            conn.Open();
            cmd.ExecuteNonQuery(); 
        }
        catch(SqlException e)
        {
            MessgeBox.Show(e.Message.ToString(), "Error Message");
        }

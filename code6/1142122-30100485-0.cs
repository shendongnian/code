    try
    {
       Your code
       //throw new Exception("he'\"");
    }
    catch(Exception ex)
    {
       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Cannot Delete Exception Message: " + ex.Message.Replace("'", "").Replace("\"", "") + "');", true);
    }
    finally //Close db Connection if it is open....  
    {
       if (connection.State == ConnectionState.Open)
          connection.Close();
    }

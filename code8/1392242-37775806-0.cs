    catch (MySqlException ex)
    {
      if (ex.Message.Contains("connection"))
         {
           // do stuff when connection trouble
         }
      else
        {
           // do stuff when MySql trouble
        }
    }

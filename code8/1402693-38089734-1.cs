    using(SqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            conn.Open();
        }
        catch(SqlException ex)
        {
            switch(ex.Number) 
            { 
                case 18456: // Can't login
                    // Do something
                    break;
                default:
                    break;
            } 
        }
    }

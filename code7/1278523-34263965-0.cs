    using(MySqlConnection conn = new MySqlConnetion(local_connection_string)
    {
        conn.open();
        MySqlCommand query = new MySqlCommand(
                    "here some mysql command"
                    , connect);
                query.ExecuteNonQuery();
    
    }

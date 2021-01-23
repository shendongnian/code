    // add seconds if you want, but i don't see any reason for it
    // maybe you want to include the To-date, then you can add a day - one second
    DateTo.Value = DateTo.Value.AddDays(1).AddSeconds(-1);
    using (MySqlConnection conn = new MySqlConnection("connStr"))
    {
        try
        {
            conn.Open();
            string sql = @"SELECT t.From, t.To, OtherColumns...
                           FROM TableName t 
                           WHERE FROM >= @From AND To <= @To";
            using(MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@From", DateFrom.Value);
                cmd.Parameters.AddWithValue("@To", DateTo.Value);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        // ...
                    }
                }
            }
        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

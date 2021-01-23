    using(var cn = new MySqlConnection(conString))
    using(var cmd = cn.CreateCommand())
    {
       cmd.CommandText = "insert into flight(flight_schedule) values (@date)";
       cmd.Parameters.Add("@date", MySqlDbType.Datetime).Value = MydateTimePicker.Value;
       // I assume you change your column type to Datetime
       cn.Open();
       cmd.ExecuteNonQuery();
    }

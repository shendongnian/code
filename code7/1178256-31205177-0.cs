    using (connection)
    {
        OracleCommand command = new OracleCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.BindByName = true;
        command.CommandText =
            "SELECT BOXID, PUMP_BIT, \"DATE\", \"HOUR\", RUN_DURATION, POWER_ONS " +
            "  FROM PUMP_AGG_HOURLY " +
            "  WHERE BOXID = :BoxID AND PUMP_BIT = :BitPumpe " +
            "    AND \"DATE\" BETWEEN to_date(:Date1,'dd/mm/yyyy hh24:mi:ss') " +
            "                     and to_date(:Date2,'dd/mm/yyyy hh24:mi:ss')" +
            "  ORDER BY \"DATE\", \"HOUR\"";
        command.Parameters.Add("BoxID", '1');
        command.Parameters.Add("BitPumpe", '4');
        command.Parameters.Add("Date1", "30/01/2015 01:00:00");
        command.Parameters.Add("Date2", "30/01/2015 18:00:00");
        OracleDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetString(0) + ", " + reader.GetString(1));
            Console.WriteLine(reader.GetDateTime(2));
        }
    }

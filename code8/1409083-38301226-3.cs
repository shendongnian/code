    private void send_serial_data(string port_name)
    {
        using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
        using (SerialPort sp = new SerialPort(port_name, 9600, Parity.None, 8, StopBits.One))
        {
            MyConn2.Open();
            sp.Open();
            // A query that returns all records with an ID lower than 20
            String Query = @"SELECT * FROM warehouse_data.display where Article_ID < 20";
            using (MySqlCommand cmd = new MySqlCommand(Query, MyConn2))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                // Read one record 
                while (reader.Read())
                {
                    
                    StringBuilder sb = new StringBuilder();
                    // Accumulate the fields values in the stringbuilder
                    // separating each one with a comma
                    for (int x = 0; x < reader.FieldCount; x++)
                    {
                        if (reader.IsDBNull(x))
                            sb.Append(",")
                        else
                            sb.Append(reader[x].ToString() + ",");
                    }
                    // trim away the last comma
                    sb.Length--;
                    // And probably you need something to separate a record
                    // from the following one. For example a newline
                    sb.Append(Environment.NewLine);
                    // send it along the wire
                    sp.Write(sb.ToString());
                }
            }
        }
    }

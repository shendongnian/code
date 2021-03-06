    private void send_serial_data(string port_name)
    {
        using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
        using (SerialPort sp = new SerialPort(port_name, 9600, Parity.None, 8, StopBits.One))
        {
            MyConn2.Open();
            sp.Open();
            String Query = @"SELECT * FROM warehouse_data.display where Article_ID < 20";
            using (MySqlCommand cmd = new MySqlCommand(Query, MyConn2))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    for (int x = 0; x < reader.FieldCount; x++)
                    {
                        if (reader.IsDbNull(reader[x]))
                            sb.Append(",")
                        else
                            sb.Append(reader[x].ToString() + ",");
                    }
                    // trim away the last comma
                    sb.Length--;
                    // And probably you need something to separate a record
                    // from the following one. For example a newline
                    sb.Append(Environment.NewLine);
                    sp.Write(sb.ToString());
                }
            }
        }
    }

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string SerialQuery = "select SerialNumber from Inventory";
                command.CommandText = SerialQuery;
    
                //TO READ DATA
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboSerial.Items.Add(reader["SerialNumber"]);
                }

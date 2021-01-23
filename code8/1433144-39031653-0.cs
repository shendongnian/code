            var connectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = "<Instance_Ip>",
                UserID = "root",
                Password = "<Password>",
                Database = "<Database_Name>",
                CertificateFile = @"<Path_To_The_File>\client.pfx",
                CertificatePassword = "<Password_For_The_Cert>"
            };
            using (var conn = new MySqlConnection(connectionStringBuilder.ToString()))
            using (var cmd = conn.CreateCommand())
            {    
                cmd.CommandText = string.Format("SELECT * FROM test");
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader.GetString(0);
                    Console.WriteLine(data);
                }
            }
